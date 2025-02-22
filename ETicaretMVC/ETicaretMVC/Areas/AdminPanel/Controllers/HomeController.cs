using AutoMapper;
using BusinessLayer.Abstract;
using ETicaretMVC.ApiServices;
using ETicaretMVC.Areas.AdminPanel.APITypes;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IProductManager _prdManager;
        private readonly IMapper _mapper;
        public HomeController(IApiService apiService, IProductManager prdManager, IMapper mapper)
        {
            _apiService = apiService;
            _prdManager = prdManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> List()
        {
            var viewModel = await _apiService.GetData<List<ProductResponse>>("products", token: null);
            return View(viewModel);
        }
    }
}
