using BusinessLayer.Abstract;
using DataAccesLayer.Interface;
using FluentValidation;
using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _usrRepo;
        private readonly IValidator<UserLoginDto> _loginDtoValidator;
        public UserManager(IUserRepository usrRepo, IValidator<UserLoginDto> loginDtoValidator)
        {
            _usrRepo = usrRepo;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<User> LogIn(UserLoginDto dto)
        {
            var result = _loginDtoValidator.Validate(dto);
            if (!result.IsValid)
            {
                string errorMessages = string.Empty;

                foreach (var error in result.Errors)
                {
                    errorMessages += error.ErrorMessage + "<br/>";
                }

            }
            return await _usrRepo.LogInAsync(dto.UserName, dto.Password);
        }
    }
}
