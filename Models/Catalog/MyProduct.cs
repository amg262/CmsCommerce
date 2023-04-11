using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.ServiceLocation;

namespace CmsCommerce.Models.Catalog
{
    [CatalogContentType(GUID = "9D50D14B-12BC-42E5-BDAB-AFBE1AAE7009", MetaClassName = "MyProduct ")]
    public class MyProduct : ProductContent
    {
        [CultureSpecific]
        [IncludeInDefaultSearch]
        [Searchable]
        [Tokenize]
        public virtual XhtmlString MainBody { get; set; }

        public virtual string ClothesType { get; set; }

        public virtual string Brand { get; set; }

       // public virtual IEnumerable<MyVariation> ListOfVariation { get; set; }

        public void SetVariations(ContentReference referenceToProduct)
        {
            var relationRepository = ServiceLocator.Current.GetInstance<IRelationRepository>();
            var variations = relationRepository.GetChildren<ProductVariation>(referenceToProduct);
           // ListOfVariation = variations;
            //return variations;
        }
        
        

    }
}