using Microsoft.EntityFrameworkCore;
using ultraplay_task.Models;

namespace ultraplay_task.Services.SportService
{
    public class SportService : ISportService
    {
        private readonly UltraplayTaskDbContext _context;

        public SportService(UltraplayTaskDbContext context)
        {
            _context = context;
        }

        public List<Sport> All()
        {
            return _context.Sports.Include(_ => _.Events).ThenInclude(_ => _.Matches)
                .ThenInclude(_ => _.Bets).ThenInclude(_ => _.Odds).ToList();
        }

        public async Task<List<Sport>> AllAsync()
        {
            return await _context.Sports.Include(_ => _.Events).ThenInclude(_ => _.Matches)
                .ThenInclude(_ => _.Bets).ThenInclude(_ => _.Odds).ToListAsync();
        }

        public Sport Create(Sport sport)
        {
            _context.Sports.Add(sport);
            _context.SaveChanges();
            return sport;
        }

        public async Task<Sport> CreateAsync(Sport sport)
        {
            _context.Sports.Add(sport);
            await _context.SaveChangesAsync();
            return sport;
        }

        public Sport Delete(int id)
        {
            Models.Sport sport = _context.Sports.FirstOrDefault(x => x.Id == id);
            _context.Sports.Remove(sport);
            _context.SaveChanges();
            return sport;
        }

        public async Task<Sport> DeleteAsync(int id)
        {
            Models.Sport sport = await _context.Sports.FirstOrDefaultAsync(x => x.Id == id);
            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();
            return sport;
        }

        public Sport Get(int id)
        {
            return _context.Sports.Include(_ => _.Events).ThenInclude(_ => _.Matches)
                .ThenInclude(_ => _.Bets).ThenInclude(_ => _.Odds).Where(x => x.Id == id)
              .FirstOrDefault();
        }

        public async Task<Sport> GetAsync(int id)
        {
            return await _context.Sports.Include(_ => _.Events).ThenInclude(_ => _.Matches)
                .ThenInclude(_ => _.Bets).ThenInclude(_ => _.Odds).Where(x => x.Id == id)
              .FirstOrDefaultAsync();
        }

        public Sport Update(Sport sport)
        {
            Models.Sport sportToUpdate = _context.Sports
                            .Where(x => x.Id == sport.Id)
                            .FirstOrDefault();

            sportToUpdate = sport;

            _context.Sports.Update(sportToUpdate);
            _context.SaveChanges();

            return sport;
        }

        public async Task<Sport> UpdateAsync(Sport sport)
        {
            Models.Sport sportToUpdate = await _context.Sports.Where(x => x.Id == sport.Id).FirstOrDefaultAsync();

            sportToUpdate = sport;

            _context.Sports.Update(sportToUpdate);
            await _context.SaveChangesAsync();

            return sport;
        }
    }
}
