using CmsCommerce.Models.Pages;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CmsCommerce
{
    public class CmsCommercePageController : PageController<CmsCommercePage>
    {
        [HttpGet]
        public IActionResult Index(CmsCommercePage currentPage)
        {
            return View(currentPage);
        }
    }
}