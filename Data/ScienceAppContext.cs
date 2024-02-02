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

        public DbSet<ScienceApp.Models.Curriculum> Curriculum { get; set; } = default!;


    }
}
