using BusinessLayer.Abstract;
using DataAccesLayer.Interface;
using ModelLayer.Dtos;
using ModelLayer.Entities;

namespace BusinessLayer.Managers
{

    public class PaymentManager : IPaymentManager
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<PaymentResponseDto> ProcessPaymentAsync(PaymentRequestDto paymentRequest)
        {
            if (!DateTime.TryParseExact(paymentRequest.ExpiryDate, "MM/yy", null, System.Globalization.DateTimeStyles.None, out var expiryDate))
            {
                return new PaymentResponseDto
                {
                    IsSuccessful = false,
                    Message = "Geçersiz tarih formatı. Lütfen MM/YY şeklinde giriniz."
                };
            }

            var payment = new Payment
            {
                CardHolderName = paymentRequest.CardHolderName,
                CardNumber = paymentRequest.CardNumber,
                ExpiryDate = expiryDate,
                CVV = paymentRequest.CVV,
                Amount = paymentRequest.Amount
            };

            bool isSuccessful = await _paymentRepository.ProcessPaymentAsync(payment);

            return new PaymentResponseDto
            {
                IsSuccessful = isSuccessful,
                Message = isSuccessful ? "Ödeme başarıyla gerçekleştirildi." : "Ödeme başarısız oldu."
            };
        }

    }
}

