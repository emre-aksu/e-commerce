using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IUserManager
    {
        Task<User> LogIn(UserLoginDto dto);
    }
}
