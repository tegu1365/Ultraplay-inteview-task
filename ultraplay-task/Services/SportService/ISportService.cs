namespace ultraplay_task.Services.SportService
{
    public interface ISportService
    {
        public List<Models.Sport> All();
        public Models.Sport Get(int id);
        public Models.Sport Create(Models.Sport sport);
        public Models.Sport Update(Models.Sport sport);
        public Models.Sport Delete(int id);
    }
}
