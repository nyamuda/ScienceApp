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

    public class SubjectUpdateDto
    {
        [Required]
        public string? Name { get; set; }
    }
}
