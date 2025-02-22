using DataAccesLayer.Context;
using DataAccesLayer.Interface;
using Infrastructure.DataAccess;
using ModelLayer.Entities;

namespace DataAccesLayer.Repositories
{
    public class UserRepository : BaseRepository<User, int, ECommerceDbContext>, IUserRepository
    {
        public async Task<User> LogInAsync(string userName, string password)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password);
        }
    }
}
