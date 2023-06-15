namespace ultraplay_task.Services.SportService
{
    public interface ISportService
    {
        public List<Models.Sport> All();
        public Models.Sport Get(int id);
        public Models.Sport Create(Models.Sport sport);
        public Models.Sport Update(Models.Sport sport);
        public Models.Sport Delete(int id);

        public Task<List<Models.Sport>> AllAsync();
        public Task<Models.Sport> GetAsync(int id);
        public Task<Models.Sport> CreateAsync(Models.Sport sport);
        public Task<Models.Sport> UpdateAsync(Models.Sport sport);
        public Task<Models.Sport> DeleteAsync(int id);
    }
}
