using Infrastructure.DataAccess.Interface;
using ModelLayer.Entities;

namespace DataAccesLayer.Interface
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> LogInAsync(string userName, string password);
    }
}
