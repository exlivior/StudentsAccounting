using System.Threading.Tasks;
using StudentsAccounting.DTOs;

namespace StudentsAccounting.Commands
{
    public interface ICourseCommand
    {
        Task Create(CourseDTO courseDTO);
        Task Edit(CourseDTO courseDTO);
        void Delete(int id);
    }
}
