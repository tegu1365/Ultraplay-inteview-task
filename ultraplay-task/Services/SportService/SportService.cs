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

        public Sport Create(Sport sport)
        {
            _context.Sports.Add(sport);
            _context.SaveChanges();
            return sport;
        }

        public Sport Delete(int id)
        {
            Models.Sport sport = _context.Sports.FirstOrDefault(x => x.Id == id);
            _context.Sports.Remove(sport);
            _context.SaveChanges();
            return sport;
        }

        public Sport Get(int id)
        {
            return _context.Sports.Include(_ => _.Events).ThenInclude(_ => _.Matches)
                .ThenInclude(_ => _.Bets).ThenInclude(_ => _.Odds).Where(x => x.Id == id)
              .FirstOrDefault();
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
    }
}
