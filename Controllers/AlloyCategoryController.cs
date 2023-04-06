using CmsCommerce.Models.Catalog;
using CmsCommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CmsCommerce.Controllers
{
    public class AlloyCategoryController : ContentControllerBase<AlloyNode>
    {
        public ActionResult Index(AlloyNode currentContent)
        {
            var model = PageViewModel.Create<AlloyNode>(currentContent);

            return View(model);
        }

    }
}