using Microsoft.EntityFrameworkCore;
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
            return  _context.Bets.Include(_ => _.Odds).ToList();
        }

        public async Task<List<Bet>> AllAsync()
        {
            return await _context.Bets.Include(_ => _.Odds).ToListAsync();
        }

        public Bet Create(Bet bet)
        {
            _context.Bets.Add(bet);
            _context.SaveChanges();
            return bet;
        }

        public async Task<Bet> CreateAsync(Bet bet)
        {
            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();
            return bet;
        }

        public Bet Delete(int id)
        {
            Models.Bet bet = _context.Bets.FirstOrDefault(x => x.Id == id);
            _context.Bets.Remove(bet);
            _context.SaveChanges();
            return bet;
        }

        public async Task<Bet> DeleteAsync(int id)
        {
            Models.Bet bet = await _context.Bets.FirstOrDefaultAsync(x => x.Id == id);
            _context.Bets.Remove(bet);
            await _context.SaveChangesAsync();
            return bet;
        }

        public Bet Get(int id)
        {
            return _context.Bets.Where(x => x.Id == id)
                          .FirstOrDefault();
        }
        public async Task<Bet> GetAsync(int id)
        {
            return await _context.Bets.Where(x => x.Id == id)
                          .FirstOrDefaultAsync();
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

        public async Task<Bet> UpdateAsync(Bet bet)
        {
            Models.Bet betToUpdate = await _context.Bets
                                                   .Where(x => x.Id == bet.Id)
                                                   .FirstOrDefaultAsync();

            betToUpdate = bet;

            _context.Bets.Update(betToUpdate);
            await _context.SaveChangesAsync();

            return bet;
        }
    }
}
