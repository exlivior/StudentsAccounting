using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using StudentsAccounting.Entities;
using StudentsAccounting.Data;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.Queries
{
    public class CourseQuery : ICourseQuery
    {
        private readonly IQueryable<Course> courses;
        private readonly IMapper mapper;

        public CourseQuery(AppDbContext context, IMapper mapper) 
        {
            courses = context.Courses.AsNoTracking();
            this.mapper = mapper;
        }

        public async Task<List<CourseDTO>> GetAll()
        {
            return await courses.ProjectTo<CourseDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CourseDTO> Get(int id)
        {
            return await courses.ProjectTo<CourseDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(course => course.Id == id);
        }
    }
}
