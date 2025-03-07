﻿namespace BaseLib.Utilities.Security
{
   public class AccessToken
    {
        // Bu sınıfın nesneini oluşturup token'ı talep eden client'a göndreceğiz
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public List<string> Claims { get; set; }
    }
}
