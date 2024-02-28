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
            //the subject model has a many one relationship with the curriculum model
            //it should cascade on delete
            modelBuilder.Entity<Subject>()
                .HasOne<Curriculum>(s => s.Curriculum)
                .WithMany()
                .HasForeignKey(s => s.CurriculumId)
                .OnDelete(DeleteBehavior.Cascade);





        }


    }
}
