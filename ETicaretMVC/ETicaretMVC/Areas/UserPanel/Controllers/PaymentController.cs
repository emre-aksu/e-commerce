using ETicaretMVC.ApiServices;
using ETicaretMVC.Areas.UserPanel.APITypes;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dtos;
using System.Text.Json;

namespace ETicaretMVC.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class PaymentController : Controller
    {
        private readonly IApiService _apiService;
        public PaymentController(IApiService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PaymentAddDto dto)
        {
            var requestObject = new PaymentPostRequest();
            requestObject.CardHolderName = dto.CardHolderName;
            requestObject.CardNumber = dto.CardNumber;
            requestObject.ExpiryDate = dto.ExpiryDate;
            requestObject.CVV = dto.CVV;
            requestObject.Amount = dto.Amount;
            string jsonPostData = JsonSerializer.Serialize(requestObject);
            var postResult = await _apiService.PostData("payment", jsonPostData, token: null);

            if (postResult)
            {
                // Başarı durumunda View'e ödeme başarılı mesajını gönderiyoruz.
                ViewBag.SuccessMessage = "Ödeme işlemi başarılı!";
                return View(); // Aynı view'e dönecek
            }

            // Hata durumunda ViewBag ile hata mesajı gönderilir
            ViewBag.ErrorMessage = "Ödeme işlemi başarısız!";
            return View();
        }

    }
}
