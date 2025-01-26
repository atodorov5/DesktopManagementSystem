using ManagementSystem.Data;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Services
{
    public class UserService : IUserService
    {
        public AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }
    }
}
