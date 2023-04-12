using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace CmsCommerce.Models.Catalog
{
    [CatalogContentType(GUID = "612F6686-F528-42B0-AADF-DEDB059DAFCA", MetaClassName = "MyVariation ")]
    public class MyVariation : VariationContent
    {
        [CultureSpecific]
        [IncludeInDefaultSearch]
        [Searchable]
        [Tokenize]
        public virtual XhtmlString MainBody { get; set; }

        [Searchable]
        [Tokenize]
        [IncludeInDefaultSearch]
        [BackingType(typeof(PropertyLongString))]
        [Display(Name = "Size", Order = 1)]
        public virtual string Size { get; set; }

        [Searchable]
        [CultureSpecific]
        [Tokenize]
        [IncludeInDefaultSearch]
        [BackingType(typeof(PropertyLongString))]
        [Display(Name = "Color", Order = 2)]
        public virtual string Color { get; set; }

        public virtual bool CanBeMonogrammed { get; set; }

        public virtual string ThematicTag { get; set; }
    }
}