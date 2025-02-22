using ETicaretMVC.ApiServices;
using ETicaretMVC.Areas.UserPanel.APITypes;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    //--------------------------USER PANEL CATEGORY CONTROLLER---------------
    public class CategoryController : Controller
    {
        private readonly IApiService _apiService;
        public CategoryController(IApiService ariService)
        {
            _apiService = ariService;
        }
        public async Task<IActionResult> List()
        {
            var viewModel = await _apiService.GetData<List<CategoryResponse>>("userCategory", token: null);
            return View(viewModel);
        }
    }
}
