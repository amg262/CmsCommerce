using AlloyCommerce.Business.Rendering;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace CmsCommerce.Models.Catalog
{
    [CatalogContentType(DisplayName = "Variation",
    GroupName = "Commerce",
    MetaClassName = "Alloy_Variation",
    GUID = "9DB88534-AC92-4E0E-BA44-00C5372DBE75")]
    public class AlloyVariation : VariationContent, ISiteContent
    {
        public string LanguageBranch
        {
            get { return this.Language.Name; }
        }

        public virtual string MetaTitle { get; set; }
        public virtual string MetaDescription { get; set; }
    }
}