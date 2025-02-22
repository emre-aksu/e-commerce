using ETicaretMVC.Areas.AdminPanel.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [CheckSession]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
