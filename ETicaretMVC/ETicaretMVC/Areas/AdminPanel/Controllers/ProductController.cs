using AutoMapper;
using BusinessLayer.Abstract;
using DataAccesLayer.Context;
using ETicaretMVC.ApiServices;
using ETicaretMVC.Areas.AdminPanel.APITypes;
using ETicaretMVC.Areas.AdminPanel.Filters;
using ETicaretMVC.Areas.AdminPanel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dtos;
using ModelLayer.Entities;
using System.Text.Json;

namespace ETicaretMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [CheckSession]

    public class ProductController : Controller
    {
    
        private readonly IApiService _apiService;
        private readonly IProductManager _prdManager;
        private readonly IMapper _mapper;
        public ProductController(IApiService apiService, IProductManager prdManager, IMapper mapper)
        {
            _apiService = apiService;
            _prdManager = prdManager;
            _mapper = mapper;
        }
       

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _apiService.GetData<List<ProductResponse>>("products", token: null);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Add()
        {


            using (var ctx = new ECommerceDbContext())
            {
                var model = new ProductAddViewModel();
                model.CategoryList = ctx.Categories.ToList();
                return View(model);

            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto dto)
        {
            #region VALIDASYON ORNEGİ
            List<Category> categories;
            using (var ctx = new ECommerceDbContext())
            {

                categories = ctx.Categories.ToList();

            }

            if (dto.CategoryId == -1)
            {
                ViewBag.Errormessage = "Lütfen kategori seçiniz";
                return View(categories);
            }
            #endregion



            var requestObject = new ProductPostRequest();
            requestObject.Description = dto.Description;
            requestObject.Price = dto.Price;
            requestObject.CategoryId = dto.CategoryId;
            requestObject.Stock = dto.Stock;
            requestObject.Name = dto.Name;

            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

            using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
            {
                await dto.Photo.CopyToAsync(fs);
                requestObject.PhotoPath = $@"\productImages\{fileName}";
                fs.Close();
            }
            string jsonPostData = JsonSerializer.Serialize(requestObject);
            var postResult = await _apiService.PostData("products", jsonPostData, token: null);
            Console.WriteLine(jsonPostData);


            if (postResult)
                return RedirectToAction("List");


            return Json(new { IsSuccess = false });

        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var product = await _apiService.GetData<ProductResponse>($"products/{id}", token: null);
            var categories = await _apiService.GetData<List<Category>>("categories", token: null); // Tüm kategorileri al

            product.CategoryList = categories; // Kategori listesini ekle

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditDto dto)   
        {
            if (dto == null || dto.Id <= 0)
            {
                ModelState.AddModelError("", "Geçersiz ürün bilgileri.");
                return View(dto);
            }

            var requestObject = new ProductPutRequest
            {
                Id = dto.Id, // Burada Id'nin doğru alındığından emin olun
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };

            // Fotoğraf güncelleme kısmı
            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\productImages\\";
            if (dto.Photo != null)
            {
                // Eski fotoğrafın yolu var mı kontrol et
                if (!string.IsNullOrEmpty(dto.PhotoPath))
                {
                    var oldFilePath = Path.Combine(rootPath, dto.PhotoPath.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath); // Eski dosyayı sil
                    }
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

                using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
                {
                    await dto.Photo.CopyToAsync(fs);
                    requestObject.PhotoPath = $@"\productImages\{fileName}";
                }
            }
            else
            {
                // Yeni bir fotoğraf yüklenmediyse eski fotoğrafı koru
                requestObject.PhotoPath = dto.PhotoPath;
            }

            // API çağrısını yap
            string jsonPostData = JsonSerializer.Serialize(requestObject);
            var result = await _apiService.PutData("products", jsonPostData, token: null);

            if (result)
                return RedirectToAction("List");

            else
                throw new Exception("Hata");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiService.DeleteData($"products/{id}");

            if (result)

                return Json(new { IsSuccess = true });

            else
                throw new Exception("hata oldu");

        }


    }
}
