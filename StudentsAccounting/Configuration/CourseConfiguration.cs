using StudentsAccounting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentsAccounting.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public virtual void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
        }
    }
}
