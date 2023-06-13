using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ultraplay_task.Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [EnumDataType(typeof(MatchType))]
        public MatchType MatchType { get; set; }
        public ICollection<Bet> Bets { get; set; }
        public Event Event { get; set; }
    }

    public enum MatchType
    {
        PreMatch,
        Live,
        Outright
    }
}
