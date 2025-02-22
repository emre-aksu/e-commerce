using DataAccesLayer.Interface;
using ModelLayer.Entities;

namespace DataAccesLayer.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<bool> ProcessPaymentAsync(Payment payment)
        {
            await Task.Delay(1000); // Simulated delay
            var random = new Random();
            return random.Next(0, 2) == 1; // %50 başarı
        }

    }
}
