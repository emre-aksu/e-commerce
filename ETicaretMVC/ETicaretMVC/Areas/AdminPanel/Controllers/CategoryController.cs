using ETicaretMVC.ApiServices;
using ETicaretMVC.Areas.AdminPanel.APITypes;
using ETicaretMVC.Areas.AdminPanel.Filters;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dtos;
using System.Text.Json;

namespace ETicaretMVC.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    [CheckSession]
    public class CategoryController : Controller
    {
        private readonly IApiService _apiService;
        public CategoryController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var jwtToken = HttpContext.Session.GetString("JwtToken");

            var viewModel = await _apiService.GetData<List<CategoryResponse>>("categories", token: jwtToken);

            return View(viewModel.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto dto)
        {
            var requestObject = new CategoryPostRequest();
            requestObject.Description = dto.Description;
            requestObject.Name = dto.Name;
            // requestObject.PhotoPath=dto.Photo.GetType(IFormFile);
            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\categoryImages\\";
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

            using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
            {
                await dto.Photo.CopyToAsync(fs);
                requestObject.PhotoPath = $@"\categoryImages\{fileName}";
                fs.Close();
            }
            string jsonPostData = JsonSerializer.Serialize(requestObject);
            var postResult = await _apiService.PostData("categories", jsonPostData, token: null);

            if (postResult)
                return RedirectToAction("List");


            return Json(new { IsSuccess = false });


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var category = await _apiService.GetData<CategoryResponse>($"categories/{id}", token: null);

            return View(category);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditDto dto)
        {
            var requestObject = new CategoryPutRequest();
            requestObject.Id = dto.CategoryId;
            requestObject.Name = dto.Name;
            requestObject.Description = dto.Description;

            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\categoryImages\\";

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

            using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
            {
                await dto.Photo.CopyToAsync(fs);
                requestObject.PhotoPath = $@"\categoryImages\{fileName}";
                fs.Close();
            }

            string jsonPostData = JsonSerializer.Serialize(requestObject);
            var result = await _apiService.PutData("categories", jsonPostData, token: null);


            if (result)
                return RedirectToAction("List");

            else
                throw new Exception("hata");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiService.DeleteData($"categories/{id}");

            if (result)

                return Json(new { IsSuccess = true });

            else
                throw new Exception("hata oldu");

        }

    }
}
