using AutoMapper;
using OnlineWS.Business.Contracts;
using OnlineWS.DateAccess.Contracts.Repositories;
using OnlineWSModel.Dtos.PaymentDto;
using OnlineWSModel.Entities;

namespace OnlineWS.Business.Implementations
{
    public class PaymentManager:IPaymentManager
    {
        private readonly IPaymentRepository _paymentRepo;
        private readonly IMapper _mapper;
        public PaymentManager(IPaymentRepository paymentRepo, IMapper mapper)
        {
            _mapper = mapper;
            _paymentRepo = paymentRepo;
        }

        public async Task AddPayment(PaymentPostDto dto)
        {
            var entity = _mapper.Map< Payment>(dto);
            await _paymentRepo.InsertAsync(entity);
        }
    }
}
