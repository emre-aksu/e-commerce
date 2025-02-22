using AutoMapper;
using BusinessLayer.Abstract;
using ETicaretMVC.ApiServices;
using ETicaretMVC.Areas.UserPanel.APITypes;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretMVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    //--------------------------USER PANEL PRODUCT CONTROLLER---------------
    public class ProductController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;
        public ProductController(IApiService apiService, IProductManager productManager, IMapper mapper)
        {
            _apiService = apiService;
            _productManager = productManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _apiService.GetData<List<ProductResponse>>("userProduct", token: null);
            return View(viewModel);
        }
    }
}
