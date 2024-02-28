using System.ComponentModel.DataAnnotations;


namespace ScienceApp.Dtos
{
    public class SubjectDto
    {

        [Required]
        public string? Name { get; set; }

        [Required]
        public int CurriculumId { get; set; }
    }
}
