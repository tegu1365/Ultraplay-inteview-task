using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ultraplay_task.Models;

namespace ultraplay_task
{
    public class UltraplayTaskDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public UltraplayTaskDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("UP_database"));
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Odd> Odds { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<UpdateMessage> updates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Odd>().ToTable("odds");
            modelBuilder.Entity<Bet>().ToTable("bets");
            modelBuilder.Entity<Match>().ToTable("matches");
            modelBuilder.Entity<Event>().ToTable("events");
            modelBuilder.Entity<Sport>().ToTable("sports");
            modelBuilder.Entity<UpdateMessage>().ToTable("updates");

            modelBuilder.Entity<Bet>().HasMany<Odd>(b => b.Odds).WithOne(o => o.Bet);
            modelBuilder.Entity<Match>().HasMany<Bet>(m => m.Bets).WithOne(b => b.Match);
            modelBuilder.Entity<Event>().HasMany<Match>(e => e.Matches).WithOne(m => m.Event);
            modelBuilder.Entity<Sport>().HasMany<Event>(s => s.Events).WithOne(e => e.Sport);
        }
    }
}
