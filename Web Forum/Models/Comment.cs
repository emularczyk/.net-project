using System.ComponentModel.DataAnnotations;

namespace Web_Forum.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        public string user_id { get; set; }
        [Required]
        public int topic_id { get; set; }
    }
}
