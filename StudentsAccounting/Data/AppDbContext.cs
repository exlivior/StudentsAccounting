using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsAccounting.Entities;
using StudentsAccounting.Configuration;
using Microsoft.AspNetCore.Identity;

namespace StudentsAccounting.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Course> Courses { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
