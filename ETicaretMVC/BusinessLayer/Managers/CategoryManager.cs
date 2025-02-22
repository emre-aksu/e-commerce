using AutoMapper;
using BusinessLayer.Abstract;
using DataAccesLayer.Interface;
using FluentValidation;
using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _catRepo;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryAddDto> _categoryAddValidator;

        public CategoryManager(ICategoryRepository catRepo,
            IMapper mapper,
            IValidator<CategoryAddDto> categoryAddValidator)
        {
            _catRepo = catRepo;
            _categoryAddValidator = categoryAddValidator;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await GetById(id);

            if (category != null)
            {
                await _catRepo.DeleteAsync(category);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Category> GetById(int id, params string[] includeList)
        {
            // Loglama
            // vs

            return await _catRepo.GetByIdAsync(id, includeList);
        }

        public async Task<List<Category>> GetCategories(params string[] includeList)
        {
            // Loglama
            // vs

            return await _catRepo.GetAllAsync(navProp: includeList);
        }

        public async Task Insert(CategoryAddDto dto)
        {
            // LOGLAMA

            var result = _categoryAddValidator.Validate(dto);
            if (!result.IsValid)
            {
                string errorMessages = string.Empty;
                foreach (var error in result.Errors)
                    errorMessages += error.ErrorMessage + "<br />";

                // validasyondan geçömiyorsa mvc ye ona göre yanıt dönecek
            }

            #region DOSYAYI SUNUCUYA UPLOAD ET

            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\categoryImages\\";
            //var fileName = dto.Photo.FileName;

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

            using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
            {
                await dto.Photo.CopyToAsync(fs);
                fs.Close(); // işlemci bu stream için kullandığı kaynakları serbest bıraksın
            }


            #endregion

            var entity = _mapper.Map<Category>(dto);

            using (var stream = new MemoryStream())
            {
                await dto.Photo.CopyToAsync(stream);
                entity.Picture = stream.ToArray();
                stream.Close();
            }

            entity.PhotoPath = $@"\categoryImages\{fileName}";

            await _catRepo.InsertAsync(entity);
        }

        public async Task Update(CategoryEditDto dto)
        {
            var entity = await GetById(dto.CategoryId);

            _mapper.Map<CategoryEditDto, Category>(dto, entity);

            if (dto.Photo != null)
            {
                #region YENI DOSYAYI UPLOAD ET
                var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\categoryImages\\";

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

                using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
                {
                    await dto.Photo.CopyToAsync(fs);
                    fs.Close();
                }

                #endregion

                #region ESKI DOSYAYI SIL

                System.IO.File.Delete($"{rootPath}{entity.PhotoPath.Replace("\\categoryImages\\", "")}");

                #endregion

                using (var stream = new MemoryStream())
                {
                    await dto.Photo.CopyToAsync(stream);
                    entity.Picture = stream.ToArray();
                    stream.Close();
                }

                entity.PhotoPath = $@"\categoryImages\{fileName}";
            }


            await _catRepo.UpdateAsync(entity);
        }
    }
}
