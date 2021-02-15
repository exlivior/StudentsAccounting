using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsAccounting.Models;
using StudentsAccounting.Configuration;

namespace StudentsAccounting.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=StudentsAccounting;Integrated Security=True");
        }
    }
}
