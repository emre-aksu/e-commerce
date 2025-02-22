using FluentValidation;
using ModelLayer.Dtos;

namespace BusinessLayer.Validators.FluentValidation
{
    public class LogInDtoValidator:AbstractValidator<LogInDto>
    {
        public LogInDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı en az 3 karakterden oluşmalıdır.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(x => x.Password).MinimumLength(1).WithMessage("Şifre en az 1 karakterden oluşmalıdır.");

        }
    }
}
