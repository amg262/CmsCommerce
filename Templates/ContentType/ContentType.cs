using System.ComponentModel.DataAnnotations;

namespace CmsCommerce.Templates.ContentType
{
    [ContentType(
        DisplayName = "ContentType",
        GUID = "BA001316-5B18-45F4-BC80-1AF9DC1977AF",
        Description = "")]
    public class ContentType : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "MyProperty",
            Description = "My property description",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string MyProperty { get; set; }
    }
}
