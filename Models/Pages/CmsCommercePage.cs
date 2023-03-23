using System.ComponentModel.DataAnnotations;

namespace CmsCommerce.Models.Pages
{
    [ContentType(
        DisplayName = "CmsCommerce page",
        GUID = "934E7266-FB8C-4DEA-B033-3B4E6AE6CBCF",
        GroupName = Globals.GroupNames.Specialized,
        Description = "Other page types",
        AvailableInEditMode = true)]
    [ImageUrl("~/styles/images/page_type.png")]
    public class CmsCommercePage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title for the page",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "Main body",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString MainBody { get; set; }
    }
}