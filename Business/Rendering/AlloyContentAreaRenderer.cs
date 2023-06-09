using EPiServer.Core.Html.StringParsing;
using EPiServer.Web.Mvc.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CmsCommerce.Business.Rendering
{
    /// <summary>
    /// Extends the default <see cref="ContentAreaRenderer"/> to apply custom CSS classes to each <see cref="ContentFragment"/>.
    /// </summary>
    public class AlloyContentAreaRenderer : ContentAreaRenderer
    {
        protected override string GetContentAreaItemCssClass(IHtmlHelper helper, ContentAreaItem contentAreaItem)
        {
            var tag = GetContentAreaItemTemplateTag(helper, contentAreaItem);
            return
                $"block {GetTypeSpecificCssClasses(contentAreaItem, ContentRepository)} {GetCssClassForTag(tag)} {tag}";
        }

        /// <summary>
        /// Gets a CSS class used for styling based on a tag name (ie a Bootstrap class name)
        /// </summary>
        /// <param name="tagName">Any tag name available, see <see cref="Globals.ContentAreaTags"/></param>
        private static string GetCssClassForTag(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                return "";
            }

            return tagName.ToLower() switch
            {
                "span12" => "full",
                "span8" => "wide",
                "span6" => "half",
                _ => string.Empty
            };
        }

        private static string GetTypeSpecificCssClasses(ContentAreaItem contentAreaItem,
            IContentRepository contentRepository)
        {
            var content = contentAreaItem.LoadContent();
            var cssClass = content == null ? string.Empty : content.GetOriginalType().Name.ToLowerInvariant();

            if (content is ICustomCssInContentArea customClassContent &&
                !string.IsNullOrWhiteSpace(customClassContent.ContentAreaCssClass))
            {
                cssClass += $" {customClassContent.ContentAreaCssClass}";
            }

            return cssClass;
        }
    }
}