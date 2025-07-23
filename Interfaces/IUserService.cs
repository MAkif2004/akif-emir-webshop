using WebShopLearning.Models;

namespace WebShopLearning.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> getAllUsersAsync();
    }
}