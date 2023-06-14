using Microsoft.EntityFrameworkCore;
using ultraplay_task.Models;

namespace ultraplay_task.Services.OddService
{
    public class OddService : IOddService
    {
        private readonly UltraplayTaskDbContext _context;

        public OddService(UltraplayTaskDbContext context)
        {
            _context = context;
        }

        public List<Odd> All()
        {
            return  _context.Odds.ToList();
        }

        public Odd Create(Odd odd)
        {
            _context.Odds.Add(odd);
            _context.SaveChanges();
            return odd;
        }

        public Odd Delete(int id)
        {
            Models.Odd odd =  _context.Odds.FirstOrDefault(x => x.Id == id);
            _context.Odds.Remove(odd);
            _context.SaveChanges();
            return odd;
        }

        public Odd Get(int id)
        {
            return _context.Odds.Where(x => x.Id == id).FirstOrDefault();
        }

        public Odd Update(Odd odd)
        {
            Models.Odd oddToUpdate = _context.Odds.Where(x => x.Id == odd.Id)
                .FirstOrDefault();

            oddToUpdate = odd;

            _context.Odds.Update(oddToUpdate);
            _context.SaveChanges();

            return odd;
        }
    }
}
