using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CmsCommerce.Templates.ContentComponent
{
    public class Templates : PartialContentComponent<BlockData>
    {
        protected override IViewComponentResult InvokeComponent(BlockData currentContent)
        {
            return View(currentContent);
        }
    }
}
