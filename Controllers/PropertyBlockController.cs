using CmsCommerce.Models.Blocks;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CmsCommerce.Controllers;

[TemplateDescriptor(Inherited = true)]
public class PropertyBlockController : BlockController<PropertyBlock>
{
    public override ActionResult Index(PropertyBlock currentContent)
    {
        return View("~/PropertyBlocks/{typeName}.cshtml", currentContent);
    }
}