using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.Commands
{
    public interface ICommand
    {
        Task CreateCourse(CourseDTO course);
        void DeleteCourse(int id);
    }
}
