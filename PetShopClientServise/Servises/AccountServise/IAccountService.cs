using Microsoft.AspNetCore.Mvc;
using PetShopClientServise.DtoModels;
using PetShopClientServise.DtoModels.AccountModels;
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
        public Task<(ActionResult<UserInfoModelForCilent>, HttpStatusCode)> Login(LoginModel loginModel);

        public Task<HttpStatusCode> Register(RegisterModel registerModel);
    }
}
