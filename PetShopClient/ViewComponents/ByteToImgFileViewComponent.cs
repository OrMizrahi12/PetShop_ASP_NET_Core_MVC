using Microsoft.AspNetCore.Mvc;

namespace PetShopClient.ViewComponents
{
    public class ByteToImgFileViewComponent : ViewComponent
    {
        public string Invoke(byte[] imgByte)
        {
            var base64 = Convert.ToBase64String(imgByte);
            var imgSrc = string.Format("data:image/gif;base64,{0}", base64);
            return imgSrc;
        }
    }
}
