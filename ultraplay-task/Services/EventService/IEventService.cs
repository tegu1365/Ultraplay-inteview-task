namespace ultraplay_task.Services.EventService
{
    public interface IEventService
    {
        public List<Models.Event> All();
        public Models.Event Get(int id);
        public Models.Event Create(Models.Event _event);
        public Models.Event Update(Models.Event _event);
        public Models.Event Delete(int id);

        public Task<List<Models.Event>> AllAsync();
        public Task<Models.Event> GetAsync(int id);
        public Task<Models.Event> CreateAsync(Models.Event _event);
        public Task<Models.Event> UpdateAsync(Models.Event _event);
        public Task<Models.Event> DeleteAsync(int id);
    }
}
