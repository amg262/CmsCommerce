using AlloyCommerce.Business.Rendering;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace CmsCommerce.Models.Catalog
{
    [CatalogContentType(DisplayName = "Category/Node",
        GroupName = "Commerce",
        MetaClassName = "Alloy_Node",
        GUID = "094A1AFE-727A-44A0-A074-36BA07F2D092")]
    public sealed class AlloyNode : NodeContent, ISiteContent
    {
        public string LanguageBranch => this.Language.Name;
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}