using CmsCommerce.Models.Catalog;
using Mediachase.Commerce;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CmsCommerce.Models.ViewModels
{
    public class MyProductViewModel
    {
        public MyProduct Product { get; set; }
        public Money? DiscountedPrice { get; set; }
        public Money ListingPrice { get; set; }
        public MyVariation Variant { get; set; }
        public IList<SelectListItem> Colors { get; set; }
        public IList<SelectListItem> Sizes { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public bool IsAvailable { get; set; }
    }
}