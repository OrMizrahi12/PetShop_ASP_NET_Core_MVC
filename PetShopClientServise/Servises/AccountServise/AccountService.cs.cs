using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.AccountServise
{
    public class AccountService : IAccountService
    {
        public Task<HttpStatusCode> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Register()
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Unregister()
        {
            throw new NotImplementedException();
        }
    }
}
