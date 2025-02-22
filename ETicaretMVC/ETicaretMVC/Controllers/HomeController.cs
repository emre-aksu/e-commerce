using ETicaretMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaretMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

     
    }
}
