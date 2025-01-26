using ManagementSystem.Models;

namespace ManagementSystem.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserEntity>> GetUsersAsync();
    }
}
