using CmsCommerce.Models.Pages;
using CmsCommerce.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CmsCommerce.Controllers
{
    public class CmsCommercePageController : PageController<CmsCommercePage>
    {
        [HttpGet]
        public IActionResult Index(CmsCommercePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            return View(model);
        }
    }
}