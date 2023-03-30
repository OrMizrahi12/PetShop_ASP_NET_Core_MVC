using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Utils.HttpClientUtils
{
    internal class HttpClientInfo
    {
        public static readonly HttpClient HttpClientServises = new()
        {
            BaseAddress = new Uri("https://localhost:7058/")
        };
    }
}
