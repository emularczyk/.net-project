using System.ComponentModel.DataAnnotations;

namespace Web_Forum.Models
{
    public class Topic
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        public int user_id { get; set; }
    }
}
