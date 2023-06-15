using System.ComponentModel.DataAnnotations;

namespace ultraplay_task.Models
{
    public class UpdateMessage
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public UpdateType Type { get; set; }
        [Required]
        public object Item { get; set; }
    }

    public enum UpdateType
    {
        Hide,
        Change
    }
}
