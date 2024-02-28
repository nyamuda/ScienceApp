using System.ComponentModel.DataAnnotations;

namespace ScienceApp.Models
{
    public class Curriculum
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }



    }
}
