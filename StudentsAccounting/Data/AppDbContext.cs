using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsAccounting.Models;
using StudentsAccounting.Configuration;

namespace StudentsAccounting.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Course> Courses { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
