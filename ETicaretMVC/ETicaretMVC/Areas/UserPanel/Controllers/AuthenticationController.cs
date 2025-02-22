using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dtos;
using System.Text.Json;

namespace ETicaretMVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class AuthenticationController : Controller
    {
        private readonly IUserManager _userManager;
        public AuthenticationController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserLoginDto dto)
        {
            var user = await _userManager.LogIn(dto);
            if (user == null)
            {
                return Json(new { IsSuccess = false, Message = "böyle bir kullanıcı yok" });
            }
            else
            {
                HttpContext.Session.SetString("LoggenInUser", JsonSerializer.Serialize(user));
                return Json(new { IsSuccess = true });
            }
        }
    }
}
