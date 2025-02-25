namespace BaseLib.Utilities.Security
{
   public class TokenOptions
    {
        // appsettingsdeki TokenOptions key i altındaki datayı nesneleştirmek
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int TokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
