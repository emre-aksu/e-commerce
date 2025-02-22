using ETicaretMVC.ApiServices;
using ETicaretMVC.Areas.AdminPanel.APITypes;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserCategoryController : Controller
    {
        private readonly IApiService _apiService;

        public UserCategoryController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> List()
        {
            var viewModel = await _apiService.GetData<List<CategoryResponse>>("categories", token: null);
            return View(viewModel);
        }
    }
}
