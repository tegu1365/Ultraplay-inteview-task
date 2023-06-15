using Microsoft.EntityFrameworkCore;
using ultraplay_task.Models;

namespace ultraplay_task.Services.MatchService
{
    public class MatchService : IMatchService
    {
        private readonly UltraplayTaskDbContext _context;

        public MatchService(UltraplayTaskDbContext context)
        {
            _context = context;
        }

        public List<Match> All()
        {
            return _context.Matches.Include(_ => _.Bets).ThenInclude(_=>_.Odds).ToList();
        }

        public async Task<List<Match>> AllAsync()
        {
            return await _context.Matches.Include(_ => _.Bets).ThenInclude(_ => _.Odds).ToListAsync();
        }

        public Match Create(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
            return match;
        }

        public async Task<Match> CreateAsync(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public Match Delete(int id)
        {
            Models.Match match = _context.Matches.FirstOrDefault(x => x.Id == id);
            _context.Matches.Remove(match);
            _context.SaveChanges();
            return match;
        }

        public async Task<Match> DeleteAsync(int id)
        {
            Models.Match match = await _context.Matches.FirstOrDefaultAsync(x => x.Id == id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public Match Get(int id)
        {
            return _context.Matches.Include(_ => _.Bets).ThenInclude(_ => _.Odds).Where(x => x.Id == id)
            .FirstOrDefault();
        }

        public async Task<Match> GetAsync(int id)
        {
            return await _context.Matches.Include(_ => _.Bets).ThenInclude(_ => _.Odds).Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        }

        public Match Update(Match match)
        {
            Models.Match matchToUpdate = _context.Matches.Where(x => x.Id == match.Id)
                .FirstOrDefault();

            matchToUpdate = match;

            _context.Matches.Update(matchToUpdate);
            _context.SaveChanges();

            return match;
        }

        public async Task<Match> UpdateAsync(Match match)
        {
            Models.Match matchToUpdate = await _context.Matches.Where(x => x.Id == match.Id)
                .FirstOrDefaultAsync();

            matchToUpdate = match;

            _context.Matches.Update(matchToUpdate);
            await _context.SaveChangesAsync();

            return match;
        }
    }
}
