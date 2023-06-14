using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ultraplay_task.Models;
using ultraplay_task.Services.MatchService;

namespace ultraplay_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService matchService;

        public MatchController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet("all_next")]
        public List<Match> GetAllMatchesInNext24Hours()
        {
            List<Models.Match> matches = matchService.All()
                .Where(m => m.StartDate  <= DateTime.Now.AddHours(24) && m.StartDate >= DateTime.Now)
                .ToList();
            List<Models.Match> filteredMatches = matches.Select(match =>
            {
                match.Bets = match.Bets.Where(bet => bet.Name == "Match Winner" || 
                                    bet.Name == "Map Advantage" || bet.Name == "Total Maps Played").ToList();
                match.Bets = match.Bets.Select(bet => {
                    bet.Odds = bet.Odds.GroupBy(odds => odds.SpecialBetValue).FirstOrDefault().ToList();
                    return bet;
                    }
                ).ToList();
                return match;
            }).ToList();
            return filteredMatches;
        }

        [HttpGet("{id}")]
        public  ActionResult<Match> GetMatch(int id)
        {
            //Note: The feed returns only currently active matches, markets and odds.
            //I'm not sure how to fillter the two groups of markets if I have only active ones.
            return matchService.Get(id);
        }
    }
}
