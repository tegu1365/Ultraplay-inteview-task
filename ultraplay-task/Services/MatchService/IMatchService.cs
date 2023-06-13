namespace ultraplay_task.Services.MatchService
{
    public interface IMatchService
    {
        public List<Models.Match> All();
        public Models.Match Get(int id);
        public Models.Match Create(Models.Match match);
        public Models.Match Update(Models.Match match);
        public Models.Match Delete(int id);
    }
}
