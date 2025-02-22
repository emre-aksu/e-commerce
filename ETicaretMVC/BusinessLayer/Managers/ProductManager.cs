using AutoMapper;
using BusinessLayer.Abstract;
using DataAccesLayer.Interface;
using FluentValidation;
using ModelLayer.Dtos;
using ModelLayer.Entities;
using ModelLayer.JsonResponseObjects;

namespace BusinessLayer.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _prdRepo;
        private readonly IValidator<ProductAddDto> _productAddValidator;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository prdRepo, IValidator<ProductAddDto> productAddValidator, IMapper mapper)
        {
            _prdRepo = prdRepo;
            _productAddValidator = productAddValidator;
            _mapper = mapper;
        }


        public async Task<List<Product>> GetProducts(params string[] includeList)
        {
            return await _prdRepo.GetAllAsync(navProp: includeList);

        }

        public Task<List<Product>> GetByPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        //public async Task Insert(ProductAddDto dto)
        //{
        //    var result = _productAddValidator.Validate(dto);
        //    if (!result.IsValid)
        //    {
        //        // buradan validasyondan geçmediğini mvc ye bildirmek lazım
        //    }

        //    var entity = _mapper.Map<Product>(dto);

        //    #region DOSYAYI SUNUCUYA UPLOAD ET

        //    var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";


        //    foreach (var item in dto.Photo)
        //    {
        //        #region UPLOAD
        //        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(item.FileName)}";

        //        using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
        //        {
        //            await item.CopyToAsync(fs);
        //            fs.Close();
        //        }
        //        #endregion

        //        #region PRODUCTPHOTO INSERT
        //        var productPhoto = new ProductPhoto();
        //        entity.ProductPhotos.Add(productPhoto);

        //        productPhoto.PhotoPath = $@"\productImages\{fileName}";

        //        #endregion
        //    }



        //    #endregion

        //    await _prdRepo.InsertAsync(entity);
        //}

        public async Task<Product> GetById(int id, params string[] includeList)
        {
            return await _prdRepo.GetByIdAsync(id, includeList);
        }

        public async Task<ProductJsonResponseObject> GetProductById(int id, params string[] includeList)
        {

            var product = await GetById(id, includeList);

            return _mapper.Map<ProductJsonResponseObject>(product);
        }

        public Task Insert(CategoryAddDto dto)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryEditDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
