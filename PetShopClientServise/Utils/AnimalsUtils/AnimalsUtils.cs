using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopClientServise.Utils.AnimalsUtils
{
    public class AnimalsUtils
    {
        public static Animals PrepereImage(Animals animals)
        {
            if (animals.ImageFile != null)
            {
                animals.Picture = ImageSerialization.ImageToByteArray(animals.ImageFile);
                animals.ImageFile = null;
            }

            return animals;
        }
    }
}
