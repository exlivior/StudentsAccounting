using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.Models;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.Queries
{
    public interface IQuery
    {
        Task <List<CourseDTO>> GetAllCourses();
    }
}
