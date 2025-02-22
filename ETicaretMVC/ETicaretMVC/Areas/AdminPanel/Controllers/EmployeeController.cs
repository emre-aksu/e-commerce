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
    public class EmployeeController : Controller
    {
        private readonly IApiService _apiService;
        public EmployeeController(IApiService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _apiService.GetData<List<EmployeeResponse>>("employees", token: null);
            return View(viewModel);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddDto dto)
        {
            try
            {
                var requestObject = new EmployeePostRequest
                {

                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Address = dto.Address,
                    City = dto.City,
                    Country = dto.Country,
                    //BirthDate = dto.BirthDate,
                    //HireDate = dto.HireDate,
                    UserName = dto.UserName,
                    Password = dto.Password
                };

                var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\employeeImages\\";
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

                using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
                {
                    await dto.Photo.CopyToAsync(fs);
                    requestObject.PhotoPath = $@"\employeeImages\{fileName}";
                }

                string jsonPostData = JsonSerializer.Serialize(requestObject);
                var postResult = await _apiService.PostData("employees", jsonPostData, token: null);
                Console.WriteLine(jsonPostData);

                if (postResult)
                    return RedirectToAction("List");

                return Json(new { IsSuccess = false });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return Json(new { IsSuccess = false, Error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var empoyee = await _apiService.GetData<EmployeeResponse>($"employees/{id}", token: null);
            return View(empoyee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditDto dto)
        {
            var requestObject = new EmployeePutRequest();
            requestObject.FirstName = dto.FirstName;
            requestObject.LastName = dto.LastName;
            requestObject.Address = dto.Address;
            requestObject.City = dto.City;
            requestObject.Country = dto.Country;
            //requestObject.BirthDate = dto.BirthDate;
            //requestObject.HireDate = dto.HireDate;
            requestObject.UserName = dto.UserName;
            requestObject.Password = dto.Password;

            var rootPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\employeeImages\\";
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Photo.FileName)}";

            using (var fs = new FileStream($"{rootPath}{fileName}", FileMode.Create))
            {
                await dto.Photo.CopyToAsync(fs);
                requestObject.PhotoPath = $@"\employeeImages\{fileName}";
                fs.Close();
            }
            string jsonPostData = JsonSerializer.Serialize(requestObject);
            var result = await _apiService.PutData("employees", jsonPostData, token: null);
            if (result)
                return RedirectToAction("List");

            else
                throw new Exception("Hata Oluştu");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _apiService.DeleteData($"employees/{id}");

            if (result)
                return Json(new { IsSucces = true });

            else
                throw new Exception("Bir Hata Oluştu");


        }

    }
}
