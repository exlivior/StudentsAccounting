using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentsAccounting.Models;
using StudentsAccounting.Data;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.Queries
{
    public class CourseQuery : IQuery
    {
        private readonly AppDbContext _context;

        public CourseQuery(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<CourseDTO>> GetAllCourses()
        {
            return await _context.Courses.Select(x => CourseToDTO(x)).ToListAsync();
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
