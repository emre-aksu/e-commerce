using BusinessLayer.Abstract;
using ETicaretMVC.ApiServices;
using ETicaretMVC.Areas.AdminPanel.APITypes;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dtos;
using System.Text.Json;

namespace ETicaretMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AuthenticationController : Controller
    {
        private readonly IEmployeeManager _empManager;
        private readonly IApiService _apiService;
        public AuthenticationController(IEmployeeManager empManager, IApiService apiService)
        {
            _empManager = empManager;
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("LoggedInUser", string.Empty);
            //return Json(new { IsSucces = true });
            return RedirectToAction("LogIn");
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {

            var employee = _empManager.LogIn(dto);


            if (employee == null)
            {
                return Json(new { IsSuccess = false, Message = "Böyle bir kullanıcı yok" });
            }
            else
            {
                var tokenObj = await _apiService.GetData<TokenGetResponse>("authentication/gettoken", token: null);
                var jwtToken = tokenObj.Data.Token;

                HttpContext.Session.SetString("LoggedInUser", JsonSerializer.Serialize(employee));
                HttpContext.Session.SetString("JwtToken", jwtToken);

                return Json(new { IsSuccess = true });
            }
        }
    }
}
