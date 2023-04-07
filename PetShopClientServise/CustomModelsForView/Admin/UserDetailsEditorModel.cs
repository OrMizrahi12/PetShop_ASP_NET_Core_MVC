using Microsoft.AspNet.Identity.EntityFramework;
using PetShopClientServise.DtoModels.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.CustomModelsForView.Admin
{
    public class UserDetailsEditorModel
    {
        public UserInfoModelForCilent ? UserModelForCilent { get; set; }
        public List<IdentityRole> ? RolesList { get; set; }

    }
}
