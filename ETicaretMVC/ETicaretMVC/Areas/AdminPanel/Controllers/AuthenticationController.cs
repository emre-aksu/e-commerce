using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dtos;
using System.Text.Json;

namespace ETicaretMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AuthenticationController : Controller
    {
        private readonly IEmployeeManager _empManager;
        public AuthenticationController(IEmployeeManager empManager)
        {
            _empManager = empManager;
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
                HttpContext.Session.SetString("LoggedInUser", JsonSerializer.Serialize(employee));

                return Json(new { IsSuccess = true });
            }
        }
    }
}
