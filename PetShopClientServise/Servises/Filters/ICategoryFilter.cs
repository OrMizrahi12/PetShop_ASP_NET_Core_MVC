using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Servises.Filters
{
    public interface ICategoryFilter
    {
        public List<int> CategoryIdArray { get; }
        void AddCategoryId(int id);
    }
}
