using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Utils.Responses
{
    public class ClientResponse<T>
    {
        public T ? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }
}
