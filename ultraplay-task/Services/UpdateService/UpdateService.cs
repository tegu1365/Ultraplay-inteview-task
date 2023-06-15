using Microsoft.EntityFrameworkCore;
using ultraplay_task.Models;

namespace ultraplay_task.Services.UpdateService
{
    public class UpdateService:IUpdateService
    {
        private readonly UltraplayTaskDbContext _context;

        public UpdateService(UltraplayTaskDbContext context)
        {
            _context = context;
        }
        public List<UpdateMessage> All()
        {
            return _context.updates.ToList<UpdateMessage>();
        }

        public async Task<List<UpdateMessage>> AllAsync()
        {
            return await _context.updates.ToListAsync<UpdateMessage>();
        }

        public UpdateMessage Create(UpdateMessage upd)
        {
            _context.updates.Add(upd);
            _context.SaveChanges();
            return upd;
        }

        public async Task<UpdateMessage> CreateAsync(UpdateMessage upd)
        {
            _context.updates.Add(upd);
            await _context.SaveChangesAsync();
            return upd;
        }

        public UpdateMessage Delete(int id)
        {
            Models.UpdateMessage upd = _context.updates.FirstOrDefault(x => x.Id == id);
            _context.updates.Remove(upd);
            _context.SaveChanges();
            return upd;
        }

        public async Task<UpdateMessage> DeleteAsync(int id)
        {
            Models.UpdateMessage upd = await _context.updates.FirstOrDefaultAsync(x => x.Id == id);
            _context.updates.Remove(upd);
            await _context.SaveChangesAsync();
            return upd;
        }

        public UpdateMessage Get(int id)
        {
            return _context.updates.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<UpdateMessage> GetAsync(int id)
        {
            return await _context.updates.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public UpdateMessage Update(UpdateMessage upd)
        {
            Models.UpdateMessage updForUpdate = _context.updates
                                         .Where(x => x.Id == upd.Id)
                                         .FirstOrDefault();

            updForUpdate = upd;

            _context.updates.Update(updForUpdate);
            _context.SaveChanges();

            return upd;
        }

        public async Task<UpdateMessage> UpdateAsync(UpdateMessage upd)
        {
            Models.UpdateMessage updForUpdate =await  _context.updates
                                        .Where(x => x.Id == upd.Id)
                                        .FirstOrDefaultAsync();

            updForUpdate = upd;

            _context.updates.Update(updForUpdate);
            await _context.SaveChangesAsync();

            return upd;
        }
    }
}
