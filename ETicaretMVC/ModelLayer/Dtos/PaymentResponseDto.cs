using Infrastructure.Model;

namespace ModelLayer.Dtos
{
    public class PaymentResponseDto : IDto
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
