using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.AccountServise
{
    public interface IAccountService
    {
        public Task<HttpStatusCode> Register();
        public Task<HttpStatusCode> Unregister();
        public Task<HttpStatusCode> Logout();

    }
}
