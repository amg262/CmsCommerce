using System.ComponentModel.DataAnnotations;
using AlloyCommerce.Business.Rendering;
using CmsCommerce.Models.Blocks;
using EPiServer.Commerce.Catalog.ContentTypes;
using NLog;

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
public class ProductPage : ProductContent, ISiteContent
{
    private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
    
    public string LanguageBranch { get; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }

    public ProductPage(string languageBranch)
    {
        LanguageBranch = languageBranch;
    }


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