using itsjustaname_api.Models;
using itsjustaname_api.Services.Interfaces;

namespace itsjustaname_api.Services
{
    public class EbayStaticService : IEbayService
    {
        public EbayProductModel GetEbayProduct(string keyword)
        {
            return new EbayProductModel
            {
                Price = 219.99,
                ImageUrl = "http://thumbs4.ebaystatic.com/m/m-t38kJKKUVaDGi309wo2JA/140.jpg",
                ItemUrl =
                    "http://www.ebay.co.uk/itm/Beko-WMB61432B-Free-Standing-6Kg-1400-Spin-Slim-Depth-Washing-Machine-Black-/361504943331",
                Name = "Beko WMB61432B Free Standing 6Kg 1400 Spin Slim Depth Washing Machine - Black",
                BigImageUrl = "http://galleryplus.ebayimg.com/ws/web/361504943331_1_33_1.jpg"
            };
        }
    }
}