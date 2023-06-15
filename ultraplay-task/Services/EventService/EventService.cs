using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using ultraplay_task.Models;

namespace ultraplay_task.Services.EventService
{
    public class EventService : IEventService
    {
        private readonly UltraplayTaskDbContext _context;

        public EventService(UltraplayTaskDbContext context)
        {
            _context = context;
        }

        public List<Event> All()
        {
            return _context.Events.Include(_ => _.Matches).ThenInclude(_ => _.Bets)
                .ThenInclude(_ => _.Odds).ToList();
        }

        public async Task<List<Event>> AllAsync()
        {
            return await _context.Events.Include(_ => _.Matches).ThenInclude(_ => _.Bets)
                            .ThenInclude(_ => _.Odds).ToListAsync();
        }

        public Event Create(Event _event)
        {
            _context.Events.Add(_event);
            _context.SaveChanges();
            return _event;
        }

        public async Task<Event> CreateAsync(Event _event)
        {
            _context.Events.Add(_event);
            await _context.SaveChangesAsync();
            return _event;
        }

        public Event Delete(int id)
        {
            Models.Event _event = _context.Events.FirstOrDefault(x => x.Id == id);
            _context.Events.Remove(_event);
            _context.SaveChanges();
            return _event;
        }

        public async Task<Event> DeleteAsync(int id)
        {
            Models.Event _event = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
            _context.Events.Remove(_event);
            await _context.SaveChangesAsync();
            return _event;
        }

        public Event Get(int id)
        {
            return _context.Events.Include(_ => _.Matches).ThenInclude(_ => _.Bets)
                .ThenInclude(_ => _.Odds).Where(x => x.Id == id)
              .FirstOrDefault();
        }

        public async Task<Event> GetAsync(int id)
        {
            return await _context.Events.Include(_ => _.Matches).ThenInclude(_ => _.Bets)
                .ThenInclude(_ => _.Odds).Where(x => x.Id == id)
              .FirstOrDefaultAsync();
        }

        public Event Update(Event _event)
        {
            Models.Event eventToUpdate = _context.Events
                                       .Where(x => x.Id == _event.Id)
                                       .FirstOrDefault();

            eventToUpdate = _event;

            _context.Events.Update(eventToUpdate);
            _context.SaveChanges();

            return _event;
        }

        public async Task<Event> UpdateAsync(Event _event)
        {
            Models.Event eventToUpdate = await _context.Events
                                       .Where(x => x.Id == _event.Id)
                                       .FirstOrDefaultAsync();

            eventToUpdate = _event;

            _context.Events.Update(eventToUpdate);
            await _context.SaveChangesAsync();

            return _event;
        }
    }
}
