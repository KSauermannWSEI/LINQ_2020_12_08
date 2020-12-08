using LINQ_2020_12_08.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_2020_12_08.Data
{
    public class Context : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=LINQ;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }

}
