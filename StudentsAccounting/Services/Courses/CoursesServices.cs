using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.Data;
using StudentsAccounting.DTOs;
using StudentsAccounting.Commands;
using StudentsAccounting.Queries;

namespace StudentsAccounting.Services
{
    public class CoursesServices : ICoursesServices
    {
        private readonly AppDbContext context;
        private readonly ICourseQuery query;
        private readonly ICourseCommand command;

        public CoursesServices(AppDbContext context, ICourseQuery query, ICourseCommand command)
        {
            this.context = context;
            this.query = query;
            this.command = command;
        }

        public async Task<List<CourseDTO>> GetAll()
        {
            return await query.GetAll();
        }

        public async Task<CourseDTO> Get(int id)
        {
            return await query.Get(id);
        }

        public async Task Create(CourseDTO courseDTO)
        {
            await command.Create(courseDTO);
            await context.SaveChangesAsync();
        }

        public async Task Edit(CourseDTO courseDTO)
        {
            await command.Edit(courseDTO);
            await context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            command.Delete(id);
            context.SaveChanges();
        }
    }
}
