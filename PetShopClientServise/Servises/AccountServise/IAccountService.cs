﻿using Microsoft.AspNetCore.Mvc;
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
        public Task<bool> CheckIfAuthenticated();
        public Task<HttpStatusCode> CreateRole(RoleModel roleModel);
        public Task<HttpStatusCode> DeleteUserById(string id);
        public Task<(ActionResult<IEnumerable<UserInfoModelForCilent>>, HttpStatusCode)> GetAllUsersInfoForClient();
        Task<(UserInfoModelForCilent, HttpStatusCode)> GetCurrentUser();
        public Task<(ActionResult<UserInfoModelForCilent>, HttpStatusCode)> Login(LoginModel loginModel);
        public Task<HttpStatusCode> Logout();
        public Task<HttpStatusCode> ManageRolesOnUser(ManageRolesOnUserModel manageRolesOnUserModel);
        public Task<HttpStatusCode> Register(RegisterModel registerModel);
    }
}
