namespace ultraplay_task.Services.EventService
{
    public interface IEventService
    {
        public List<Models.Event> All();
        public Models.Event Get(int id);
        public Models.Event Create(Models.Event _event);
        public Models.Event Update(Models.Event _event);
        public Models.Event Delete(int id);
    }
}
