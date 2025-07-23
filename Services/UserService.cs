using Microsoft.EntityFrameworkCore;
using WebShopLearning.Models;
using WebShopLearning.Interfaces;

namespace WebShopLearning.Services
{
    public class UserService : IUserService
    {
        private readonly WebShopLearningDbContext _userPortalDbContext;
        public UserService(WebShopLearningDbContext studentPortalDbContext)
        {
            this._userPortalDbContext = studentPortalDbContext;
        }
        public async Task<List<User>> getAllUsersAsync()
        {
            var student = await _userPortalDbContext.User.ToListAsync();
            return student;
        }
    }
}