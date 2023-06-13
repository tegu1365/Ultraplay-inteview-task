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
            return _context.Events.ToList();
        }

        public Event Create(Event _event)
        {
            _context.Events.Add(_event);
            _context.SaveChanges();
            return _event;
        }

        public Event Delete(int id)
        {
            Models.Event _event = _context.Events.FirstOrDefault(x => x.Id == id);
            _context.Events.Remove(_event);
            _context.SaveChanges();
            return _event;
        }

        public Event Get(int id)
        {
            return _context.Events.Where(x => x.Id == id)
              .FirstOrDefault();
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
    }
}
