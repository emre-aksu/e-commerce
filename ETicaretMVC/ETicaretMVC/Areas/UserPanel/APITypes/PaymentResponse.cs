namespace ETicaretMVC.Areas.UserPanel.APITypes
{
    public class PaymentResponse
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CVV { get; set; }
        public decimal Amount { get; set; }
    }
}
