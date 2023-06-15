namespace ultraplay_task.Services.MatchService
{
    public interface IMatchService
    {
        public List<Models.Match> All();
        public Models.Match Get(int id);
        public Models.Match Create(Models.Match match);
        public Models.Match Update(Models.Match match);
        public Models.Match Delete(int id);

        public Task<List<Models.Match>> AllAsync();
        public Task<Models.Match> GetAsync(int id);
        public Task<Models.Match> CreateAsync(Models.Match match);
        public Task<Models.Match> UpdateAsync(Models.Match match);
        public Task<Models.Match> DeleteAsync(int id);
    }
}
