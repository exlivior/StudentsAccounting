using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.Models;
using StudentsAccounting.DTOs;
using StudentsAccounting.Data;

namespace StudentsAccounting.Commands
{
    public class CourseCommand : ICommand
    {
        private readonly AppDbContext _context;

        public CourseCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCourse(CourseDTO courseDTO)
        {
            await _context.Courses.AddAsync(DTOToCourse(courseDTO));
            await _context.SaveChangesAsync();
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.First(n => n.Id == id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        private static Course DTOToCourse(CourseDTO courseDTO) =>
            new Course
            {
                Title = courseDTO.Title,
                Description = courseDTO.Description
            };
    }
}
