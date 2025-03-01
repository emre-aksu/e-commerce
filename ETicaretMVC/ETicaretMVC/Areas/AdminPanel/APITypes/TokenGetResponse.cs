namespace ETicaretMVC.Areas.AdminPanel.APITypes
{
    public class TokenGetResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public List<string> Claims { get; set; }
    }
}
