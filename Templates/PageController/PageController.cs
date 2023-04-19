using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CmsCommerce.Templates.PageController
{
    [TemplateDescriptor(Inherited = true)]
    public class PageController : PageController<PageData>
    {
        public ActionResult Index(PageData currentPage)
        {
            // Implementation of action. You can create your own view model class that you pass to the view or
            // you can pass the page type model directly for simpler templates

            return View(currentPage);
        }
    }
}
