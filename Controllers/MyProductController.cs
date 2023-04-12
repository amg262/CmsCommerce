using CmsCommerce.Models.Catalog;
using EPiServer.Commerce.Catalog;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;

namespace CmsCommerce.Controllers
{
    public class MyProductController : MyControllerBase<MyProduct>
    {
        public MyProductController(IContentLoader contentLoader, UrlResolver urlResolver, AssetUrlResolver assetUrlResolver, ThumbnailUrlResolver thumbnailUrlResolver) : base(contentLoader, urlResolver, assetUrlResolver, thumbnailUrlResolver)
        {
        }

        public ActionResult Index(MyProduct currentContent)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            currentContent.SetVariations(currentContent.ContentLink);
            return PartialView(currentContent);
        }

    }
}