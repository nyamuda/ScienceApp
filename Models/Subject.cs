﻿using System.ComponentModel.DataAnnotations;

namespace ScienceApp.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public Curriculum? Curriculum { get; set; }


        public int CurriculumId { get; set; }
    }
}
