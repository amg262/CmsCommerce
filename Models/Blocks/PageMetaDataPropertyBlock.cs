using System.ComponentModel.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace CmsCommerce.Models.Blocks;

public class PageMetaDataPropertyBlock : PropertyBlock
{
    public virtual PageMetaDataPropertyBlock PageMetaData { get; set; }

    [Display(
        GroupName = Globals.GroupNames.MetaData,
        Order = 100)]
    [CultureSpecific]
    public virtual string MetaTitle { get; set; }

    [Display(
        GroupName = Globals.GroupNames.MetaData,
        Order = 200)]
    [CultureSpecific]
    [BackingType(typeof(PropertyStringList))]
    public virtual IList<string> MetaKeywords { get; set; }

    [Display(
        GroupName = Globals.GroupNames.MetaData,
        Order = 300)]
    [CultureSpecific]
    [UIHint(UIHint.Textarea)]
    public virtual string MetaDescription { get; set; }
}