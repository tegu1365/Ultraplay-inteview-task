using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ultraplay_task.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int Id { get; set; }
        [Required]
       public string Name { get; set; }
        [Required]
       public bool IsLive { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public ICollection<Match> Matches { get; set; }
        public Sport Sport { get; set; }

    }
}
