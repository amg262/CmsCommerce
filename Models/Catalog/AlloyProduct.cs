using AlloyCommerce.Business.Rendering;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace CmsCommerce.Models.Catalog
{
    [CatalogContentType(DisplayName = "Product",
    GroupName = "Commerce",
    MetaClassName = "Alloy_Product",
    GUID = "31DD9433-4FEC-4CB3-B103-F71165A1390B")]
    public class AlloyProduct : ProductContent, ISiteContent
    {
        public string LanguageBranch
        {
            get { return this.Language.Name; }
        }

        public virtual string MetaTitle { get; set; }
        public virtual string MetaDescription { get; set; }
    }
}