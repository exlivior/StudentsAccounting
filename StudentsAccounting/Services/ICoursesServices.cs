using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.Services
{
    public interface ICoursesServices
    {
        Task<List<CourseDTO>> GetAll();
        Task<CourseDTO> Get(int id);
        Task Create(CourseDTO courseDTO);
        Task Edit(CourseDTO courseDTO);
        void Delete(int id);

    }
}
