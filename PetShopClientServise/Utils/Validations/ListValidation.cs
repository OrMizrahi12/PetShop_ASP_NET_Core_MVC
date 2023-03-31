using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Utils.Validations
{
    public class ListValidation
    {
        public static bool ListNotEmpty<T>(List<T> values) => values.Count > 0;
    }
}
