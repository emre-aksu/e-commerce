using OnlineWSModel.Dtos.PaymentDto;

namespace OnlineWS.Business.Contracts
{
    public interface IPaymentManager
    {
        Task AddPayment(PaymentPostDto dto);
    }
}
