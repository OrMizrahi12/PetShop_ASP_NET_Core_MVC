using PetShopClientServise.DtoModels;
using PetShopClientServise.Utils.Serialization;

namespace PetShopClientServise.Utils.AnimalsUtils;

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
