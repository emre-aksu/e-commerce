using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interface
{
    public interface IPaymentRepository
    {
        Task<bool> ProcessPaymentAsync(Payment payment);
    }
}
