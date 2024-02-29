using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScienceApp.Models;

namespace ScienceApp.Data
{
    public class ScienceAppContext : DbContext
    {
        public ScienceAppContext(DbContextOptions<ScienceAppContext> options)
            : base(options)
        {
        }

        public DbSet<Curriculum> Curriculum { get; set; } = default!;

        public DbSet<Subject> Subject { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //there is a many to many relationship between subject and curriculum
            //it should cascade on delete
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Curriculums)
                .WithMany(c => c.Subjects)
                .UsingEntity(j => j.ToTable("CurriculumSubject"));


        }


    }
}
