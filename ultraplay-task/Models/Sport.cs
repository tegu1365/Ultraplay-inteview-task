using System.ComponentModel.DataAnnotations;

namespace ultraplay_task.Models
{
    public class Sport
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
