using Microsoft.AspNetCore.Mvc;

namespace PetShopClient.ViewComponents;

public class ImgFileToByteViewComponent : ViewComponent
{
    public async Task<byte[]> InvokeAsync(IFormFile file)
    {
        if (file == null)
        {
            return null!;
        }
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}
