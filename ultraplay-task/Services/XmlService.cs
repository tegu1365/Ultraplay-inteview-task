using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using ultraplay_task.Models;
using ultraplay_task.XMLModels;
using ultraplay_task.Services.BetService;
using ultraplay_task.Services.EventService;
using ultraplay_task.Services.MatchService;
using ultraplay_task.Services.OddService;
using ultraplay_task.Services.SportService;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using ultraplay_task.Services.UpdateService;

namespace ultraplay_task.Services
{
    public class XmlService : BackgroundService
    {
        string xmlFeedUrl = "https://sports.ultraplay.net/sportsxml?clientKey=9C5E796D-4D54-42FD-A535-D7E77906541A&sportId=2357&days=7";

        private Timer _timer;

        private readonly IServiceScopeFactory _serviceScopeFactory;
        private  ISportService _sportService;
        private  IEventService _eventService;
        private  IMatchService _matchService;
        private  IBetService _betService;
        private IOddService _oddService;
        private IUpdateService _updateService;

        public XmlService(IServiceScopeFactory serviceScopeFactory)
        {
           _serviceScopeFactory = serviceScopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //When ran for a first since it has to go throught the whole file adding all the data it
            //doesnt have the necessery time for the DB context and because of this the context is occupied when its
            //supposed to be used by the next thread.
            //The issue was found too late in the process and I to fix it I would needed to rewrite nearly the whole of this Service
            //so it can use the implemented async methods.
            _timer = new Timer(ReadXmlFeed, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private async void ReadXmlFeed(object? state)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                _sportService = scope.ServiceProvider.GetRequiredService<ISportService>();
                _eventService = scope.ServiceProvider.GetRequiredService<IEventService>();
                _matchService = scope.ServiceProvider.GetRequiredService<IMatchService>();
                _betService = scope.ServiceProvider.GetRequiredService<IBetService>();
                _oddService = scope.ServiceProvider.GetRequiredService<IOddService>();
                _updateService = scope.ServiceProvider.GetRequiredService<IUpdateService>();

                try
                {
                    using (var webClient = new WebClient())
                    {
                        string xmlData = webClient.DownloadString(xmlFeedUrl);
                        ParseAndStoreXML(xmlData);

                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Error downloading the XML feed: " + ex.Message);
                }
            }
        }

        private void ParseAndStoreXML(string xmlString)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XMLElements), new XmlRootAttribute("XmlSports"));
            
                XMLElements elem;
                using (var reader = new StringReader(xmlString))
                {
                    elem = (XMLElements)serializer.Deserialize(reader);
                }
                foreach (var sport in elem.sports)
                {
                    AddSport(sport);
                }
            }catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        private async void AddSport(XMLSport sport)
        {
            var existingSport = _sportService.Get(sport.Id);
            Sport sport1 = new Sport();
            sport1.Id = sport.Id;
            sport1.Name = sport.Name;
            sport1.Events = new List<Event>();

            if (existingSport == null)
            {
                existingSport= _sportService.Create(sport1);
            }
            foreach (var evnt in sport.Events) 
            {
                 AddEvent(evnt,sport.Id);
            }
        }

        private  void AddEvent(XMLEvent evnt,int sportId)
        {
            var existingEvent =_eventService.Get(evnt.Id);
            Event evnt1 = new Event();
            evnt1.Id = evnt.Id;
            evnt1.Name = evnt.Name;
            evnt1.IsLive = evnt.IsLive;
            evnt1.Sport = _sportService.Get(sportId);
            evnt1.CategoryID = evnt.CategoryID;
            evnt1.Matches = new List<Models.Match>();


            if (existingEvent == null)
            {
                existingEvent =  _eventService.Create(evnt1);
            }
            foreach (var match in evnt.Matches)
            {

                AddOrUpdateMatch(match, evnt.Id);
            }
        }

        private void AddOrUpdateMatch(XMLMatch match, int eventId)
        {
            var existingMatch = _matchService.Get(match.Id);
            Models.Match match1 = new Models.Match();
            match1.Id = match.Id;
            match1.Name = match.Name;
            match1.StartDate = match.StartDate;
            match1.MatchType = getMatchType(match.MatchType);
            match1.Event = _eventService.Get(eventId);
            match1.Bets = new List<Bet>();


            if (existingMatch == null)
            {
                existingMatch= _matchService.Create(match1);
            }
            else
            {
                if(match1.StartDate != existingMatch.StartDate)
                {
                    existingMatch.StartDate = match1.StartDate;
                    _matchService.Update(existingMatch);
                    AddUpdateMessageForChange(match.Id, "Match");

                }
                if (match1.MatchType != existingMatch.MatchType)
                {
                    existingMatch.MatchType = match1.MatchType;
                    _matchService.Update(existingMatch);
                    AddUpdateMessageForChange(match.Id, "Match");
                }
            }
            foreach (var bet in match.Bets)
            {

                AddBet(bet, match.Id);
            }
        }

        private void AddBet(XMLBet bet, int matchId)
        {
            var existingBet = _betService.Get(bet.Id);
            Bet bet1 = new Bet();
            bet1.Id=bet.Id;
            bet1.Name=bet.Name;
            bet1.IsLive = bet.IsLive;
            bet1.Match =_matchService.Get(matchId);
            bet1.Odds = new List<Odd>();


            if (existingBet == null)
            {
                existingBet=_betService.Create(bet1);
            }
            foreach (var odd in bet.Odds)
            {

                AddOrUpdateOdds(odd, bet.Id);
            }
        }

        private void AddOrUpdateOdds(XMLOdd odd, int betId)
        {
            var existingOdd = _oddService.Get(odd.Id);
            Odd odd1 = new Odd();
            odd1.Id=odd.Id;
            odd1.Name=odd.Name;
            odd1.Value = odd.Value;
            odd1.SpecialBetValue = odd.SpecialBetValue;
            odd1.Bet=_betService.Get(betId);

            if (existingOdd == null)
            {
                existingOdd=_oddService.Create(odd1);
            }
            else
            {
                if (odd1.Value != existingOdd.Value)
                {
                    existingOdd.Value = odd1.Value;
                    _oddService.Update(existingOdd);
                    AddUpdateMessageForChange(odd.Id, "Odd");
                }
            }
            
        }

        private void AddUpdateMessageForChange(int id, string item)
        {
            UpdateMessage update = new UpdateMessage();
            update.item = item;
            update.itemID = id;
            update.Type = UpdateType.Change;
            _updateService.Create(update);
        }

        private Models.MatchType getMatchType(string matchType)
        {
           switch(matchType){
                case "PreMatch": return Models.MatchType.PreMatch;
                case "Live": return Models.MatchType.Live;
                case "Outright": return Models.MatchType.Outright;
           }
            return Models.MatchType.Outright;
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }
    }
}
