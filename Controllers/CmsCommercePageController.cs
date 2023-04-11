using CmsCommerce.Models.Pages;
using CmsCommerce.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CmsCommerce.Controllers
{
    public class CmsCommercePageController : PageController<CmsCommercePage>
    {
        
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        [HttpGet]
        public IActionResult Index(CmsCommercePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            logger.Info(model);
            return View(model);
        }
    }
}