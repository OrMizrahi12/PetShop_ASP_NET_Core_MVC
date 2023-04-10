namespace PetShopApiServise.Utils.Serialization;

public class ImageSerialization
{
    public static byte[] ImageToByteArray(IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        formFile.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}
