using System.ComponentModel.DataAnnotations;
using CmsCommerce.Models.Blocks;
using EPiServer.Commerce.Catalog.ContentTypes;
using NLog;
using ILogger = NLog.ILogger;

namespace CmsCommerce.Models.Pages;

/// <summary>
/// Used to present a single product
/// </summary>
[SiteContentType(
    GUID = "17583DCD-3C11-49DD-A66D-0DEF0DD601FC",
    GroupName = Globals.GroupNames.Products)]
[SiteImageUrl(Globals.StaticGraphicsFolderPath + "page-type-thumbnail-product.png")]
[AvailableContentTypes(
    Availability = Availability.Specific,
    IncludeOn = new[] {typeof(StartPage)})]
public class ProductPage : StandardPage, IHasRelatedContent
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();

    [Required]
    [Display(Order = 305)]
    [UIHint(Globals.SiteUIHints.StringsCollection)]
    [CultureSpecific]
    public virtual IList<string> UniqueSellingPoints { get; set; }

    [Display(
        GroupName = SystemTabNames.Content,
        Order = 330)]
    [CultureSpecific]
    [AllowedTypes(new[] {typeof(IContentData)}, new[] {typeof(JumbotronBlock)})]
    public virtual ContentArea RelatedContentArea { get; set; }
}