namespace ultraplay_task.Services.BetService
{
    public interface IBetService
    {
        public List<Models.Bet> All();
        public Models.Bet Get(int id);
        public Models.Bet Create(Models.Bet bet);
        public Models.Bet Update(Models.Bet bet);
        public Models.Bet Delete(int id);
    }
}
