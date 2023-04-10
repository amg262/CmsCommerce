using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace CmsCommerce.Models.Catalog
{
    [CatalogContentType(DisplayName = "Category/Node",
        GroupName = "Commerce",
        MetaClassName = "Alloy_Node",
        GUID = "094A1AFE-727A-44A0-A074-36BA07F2D092")]
    public class AlloyNode : NodeContent, ISiteContent
    {
        private readonly ILogger _logger;
        
        
        public virtual string LanguageBranch => this.Language.Name;
        public virtual string MetaTitle { get; set; }
        public virtual string MetaDescription { get; set; }
    }
}