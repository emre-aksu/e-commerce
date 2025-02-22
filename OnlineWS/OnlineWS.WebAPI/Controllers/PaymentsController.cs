using Microsoft.AspNetCore.Mvc;
using OnlineWS.Business.Contracts;
using OnlineWSModel.Dtos.PaymentDto;

namespace OnlineWS.WebAPI.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentsController : Controller
    {
        private readonly IPaymentManager _paymentManager;
        public PaymentsController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] PaymentPostDto dto)
        {
            await _paymentManager.AddPayment(dto);
            return Ok();
        }
    }
}
