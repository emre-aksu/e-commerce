using AutoMapper;
using OnlineWSModel.Dtos.PaymentDto;
using OnlineWSModel.Entities;

namespace OnlineWS.Business.Mapping.Automapper.Profiles
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentPostDto, Payment>();
        }
    }
}
