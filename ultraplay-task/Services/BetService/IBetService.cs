using ultraplay_task.Models;

namespace ultraplay_task.Services.BetService
{
    public interface IBetService
    {
        public List<Models.Bet> All();
        public Models.Bet Get(int id);
        public Models.Bet Create(Models.Bet bet);
        public Models.Bet Update(Models.Bet bet);
        public Models.Bet Delete(int id);

        public Task<List<Models.Bet>> AllAsync();
        public Task<Models.Bet> GetAsync(int id);
        public Task<Models.Bet> CreateAsync(Models.Bet bet);
        public Task<Models.Bet> UpdateAsync(Models.Bet bet);
        public Task<Models.Bet> DeleteAsync(int id);
    }
}
