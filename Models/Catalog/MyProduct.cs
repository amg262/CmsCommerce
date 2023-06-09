﻿using System.ComponentModel.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Commerce.Catalog.Linking;
using EPiServer.Commerce.SpecializedProperties;
using EPiServer.ServiceLocation;

namespace CmsCommerce.Models.Catalog
{
    [CatalogContentType(
        GUID = "550ebcfc-c989-4272-8f94-c6d079f56181",
        MetaClassName = "FashionProduct",
        DisplayName = "Fashion product",
        Description = "Display fashion product")]
    public class MyProduct : ProductContent
    {
        [Searchable]
        [CultureSpecific]
        [Tokenize]
        [IncludeInDefaultSearch]
        [Display(Name = "Brand", Order = 1)]
        public virtual string Brand { get; set; }

        [Searchable]
        [CultureSpecific]
        [Tokenize]
        [IncludeInDefaultSearch]
        [Display(Name = "Description", Order = 2)]
        public virtual XhtmlString Description { get; set; }

        [Searchable]
        [CultureSpecific]
        [Tokenize]
        [IncludeInDefaultSearch]
        [Display(Name = "Long Description", Order = 3)]
        public virtual XhtmlString LongDescription { get; set; }

        [Searchable]
        [CultureSpecific]
        [Tokenize]
        [IncludeInDefaultSearch]
        [Display(Name = "Sizing", Order = 4)]
        public virtual XhtmlString Sizing { get; set; }

        [CultureSpecific]
        [Display(Name = "Product Teaser", Order = 5)]
        public virtual XhtmlString ProductTeaser { get; set; }

        [Searchable]
        [IncludeInDefaultSearch]
        [BackingType(typeof(PropertyDictionaryMultiple))]
        [Display(Name = "Available Sizes", Order = 6)]
        public virtual ItemCollection<string> AvailableSizes { get; set; }

        [Searchable]
        [IncludeInDefaultSearch]
        [BackingType(typeof(PropertyDictionaryMultiple))]
        [Display(Name = "Available Colors", Order = 6)]
        public virtual ItemCollection<string> AvailableColors { get; set; }

        public void SetVariations(ContentReference referenceToProduct)
        {
            var relationRepository = ServiceLocator.Current.GetInstance<IRelationRepository>();
            var variations = relationRepository.GetChildren<ProductVariation>(referenceToProduct);
            // ListOfVariation = variations;
            //return variations;
        }
    }
}