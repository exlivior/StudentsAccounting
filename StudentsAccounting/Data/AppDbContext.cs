using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsAccounting.Models;

namespace StudentsAccounting.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Course> Courses { get; set; }

        public AppDbContext(DbContextOptions options)
: base(options)
{
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=StudentsAccounting;Integrated Security=True");
        }
    }
}
