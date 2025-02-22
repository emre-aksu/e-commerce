using FluentValidation;
using ModelLayer.Dtos;

namespace BusinessLayer.Validators.FluentValidation
{
    public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Kategori Adı Boş Bırakılamaz");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Açıklama Boş Bırakılamaz");

            RuleFor(x => x.Photo)
                .NotNull()
                .WithMessage("Resim dosyası seçmek mecburidir");

            RuleFor(x => x.Photo.ContentType)
                .Must(IsImage)
                .When(x => x.Photo != null)
                .WithMessage("Lütfen resim dosyası seçiniz");

            RuleFor(x => x.Photo.Length)
                .Must(IsLengthOk)
                .When(x => x.Photo != null)
                .WithMessage("Dosya boyutu 100KB dan büyük olamaz");
        }

        private bool IsImage(string contentType)
        {
            return contentType.StartsWith("image/");
        }
        private bool IsLengthOk(long length)
        {
            return length < (100 * 1024);
        }
    }
}
