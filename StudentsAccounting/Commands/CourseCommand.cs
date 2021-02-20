using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using StudentsAccounting.Entities;
using StudentsAccounting.DTOs;
using StudentsAccounting.Data;

namespace StudentsAccounting.Commands
{
    public class CourseCommand : ICourseCommand
    {
        private readonly DbSet<Course> courses;
        private readonly IMapper mapper;

        public CourseCommand(AppDbContext context, IMapper mapper)
        {
            courses = context.Courses;
            this.mapper = mapper;
        }

        public async Task Create(CourseDTO courseDTO)
        {
            await courses.AddAsync(mapper.Map<CourseDTO, Course>(courseDTO));
        }

        public async Task Edit(CourseDTO courseDTO)
        {
            var course = await courses.FindAsync(courseDTO.Id);

            if (course != null)
            {
                course.Title = courseDTO.Title;
                course.Description = courseDTO.Description;
            }
        }

        public void Delete(int id)
        {
            var course = courses.Find(id);
            if (course != null)
            {
                courses.Remove(course);
            }
        }
    }
}
