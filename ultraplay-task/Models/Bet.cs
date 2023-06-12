using System.ComponentModel.DataAnnotations;

namespace ultraplay_task.Models
{
    public class Bet
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsLive { get; set; }

        public ICollection<Odd> Odds { get; set; }
        public Match Match { get; set; }
    }
}
