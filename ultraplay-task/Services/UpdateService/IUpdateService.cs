namespace ultraplay_task.Services.UpdateService
{
    public interface IUpdateService
    {
        public List<Models.UpdateMessage> All();
        public Task<List<Models.UpdateMessage>> AllAsync();
        public Models.UpdateMessage Get(int id);
        public Task<Models.UpdateMessage> GetAsync(int id);

        public Models.UpdateMessage Create(Models.UpdateMessage upd);
        public Task<Models.UpdateMessage> CreateAsync(Models.UpdateMessage upd);

        public Models.UpdateMessage Update(Models.UpdateMessage upd);
        public Task<Models.UpdateMessage> UpdateAsync(Models.UpdateMessage upd);

        public Models.UpdateMessage Delete(int id);
        public Task<Models.UpdateMessage> DeleteAsync(int id);

    }
}
