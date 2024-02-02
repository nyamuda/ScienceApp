using System.ComponentModel.DataAnnotations;

namespace ScienceApp.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }


        public Subject? Subject { get; set; }
        public Curriculum? Curriculum { get; set; }
    }
}
