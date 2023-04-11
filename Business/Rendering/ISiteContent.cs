using System.Globalization;

namespace CmsCommerce.Business.Rendering
{
    public interface ISiteContent
    {
        ContentReference ContentLink { get; set; }
        CultureInfo Language { get; set; }
        string LanguageBranch { get; }
        string MetaTitle { get; set; }
        string MetaDescription { get; set; }
    }
}