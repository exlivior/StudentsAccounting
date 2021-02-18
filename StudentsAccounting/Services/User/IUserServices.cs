using System.Threading.Tasks;
using StudentsAccounting.DTOs;
using StudentsAccounting.Models;

namespace StudentsAccounting.Services
{
    public interface IUserServices
    {
        Task<UserManagerResponse> RegisterUserAsync(RegistrerRequest user);
        Task<UserManagerResponse> LoginUserAsync(AuthRequest creds);
        Task<UserManagerResponse> ConfirmEmailAsync(string userId, string token);
    }
}
