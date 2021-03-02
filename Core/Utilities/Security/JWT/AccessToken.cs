using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Erişim Anahtarı
    public class AccessToken
    {
        //Token bilgisi ve bitiş süresi
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
