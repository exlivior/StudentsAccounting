using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StudentsAccounting.Models;
using StudentsAccounting.Data;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.Queries
{
    public class CourseQuery : ICourseQuery
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public CourseQuery(AppDbContext context, IMapper mapper) 
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CourseDTO>> GetAll()
        {
            return await context.Courses.Select(x => CourseToDTO(x)).ToListAsync();
        }

        public async Task<CourseDTO> Get(int id)
        {
            var course = await context.Courses.FindAsync(id);
            return mapper.Map<CourseDTO>(course);
        }

        private static CourseDTO CourseToDTO(Course course) =>
            new CourseDTO
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description
            };
    }
}
