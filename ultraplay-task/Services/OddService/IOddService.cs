namespace ultraplay_task.Services.OddService
{
    public interface IOddService
    {
        public List<Models.Odd> All();
        public Models.Odd Get(int id);
        public Models.Odd Create(Models.Odd odd);
        public Models.Odd Update(Models.Odd odd);
        public Models.Odd Delete(int id);
    }
}
