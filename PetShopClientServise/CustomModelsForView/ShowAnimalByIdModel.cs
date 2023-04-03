using PetShopClientServise.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.CustomModelsForView
{
    public class ShowAnimalByIdModel
    {
        public Animals ? Animals { get; set; }
        public IEnumerable<Comments>? Comments { get; set; }
    }
}
