using System.ComponentModel.DataAnnotations;

namespace ScienceApp.Models
{
    public class Term
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Definition { get; set; }

        public Topic? Topic { get; set; }

    }
}
