using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.Entities;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.Queries
{
    public interface ICourseQuery
    {
        Task<List<CourseDTO>> GetAll();
        Task<CourseDTO> Get(int id);
    }
}
