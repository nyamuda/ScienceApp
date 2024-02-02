using System.ComponentModel.DataAnnotations;

namespace ScienceApp.Dtos
{
    public class CurriculumDto
    {
        [Required]
        public string? Name { get; set; }
    }
}
