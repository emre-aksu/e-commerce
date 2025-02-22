using Infrastructure.Model;

namespace ModelLayer.Dtos
{
    public class PaymentRequestDto: IDto
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; } // Format: MM/YY
        public int CVV { get; set; }
        public decimal Amount { get; set; }
    }
}
