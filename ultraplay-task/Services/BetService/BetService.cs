using ultraplay_task.Models;

namespace ultraplay_task.Services.BetService
{
    public class BetService : IBetService
    {
        private readonly UltraplayTaskDbContext _context;

        public BetService(UltraplayTaskDbContext context)
        {
            _context = context;
        }
        public List<Bet> All()
        {
            return _context.Bets.ToList();
        }

        public Bet Create(Bet bet)
        {
            _context.Bets.Add(bet);
            _context.SaveChanges();
            return bet;
        }

        public Bet Delete(int id)
        {
            Models.Bet bet = _context.Bets.FirstOrDefault(x => x.Id == id);
            _context.Bets.Remove(bet);
            _context.SaveChanges();
            return bet;
        }

        public Bet Get(int id)
        {
            return _context.Bets.Where(x => x.Id == id)
                          .FirstOrDefault();
        }

        public Bet Update(Bet bet)
        {
            Models.Bet betToUpdate = _context.Bets
                                       .Where(x => x.Id == bet.Id)
                                       .FirstOrDefault();

            betToUpdate = bet;

            _context.Bets.Update(betToUpdate);
            _context.SaveChanges();

            return bet;
        }
    }
}
