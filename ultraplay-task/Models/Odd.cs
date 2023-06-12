using System.ComponentModel.DataAnnotations;

namespace ultraplay_task.Models
{
    public class Odd
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Value { get; set; }
        public double SpecialBetValue { get; set; }
        public Bet Bet { get; set; }
    }
}
