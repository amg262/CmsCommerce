using CmsCommerce.Models.Pages;
using EPiServer.Commerce.Catalog.ContentTypes;

namespace CmsCommerce.Models.ViewModels;

public class ProductViewModel<T> : IProductViewModel<T> where T : ProductContent
{
    public ProductViewModel(T currentPage)
    {
        CurrentPage = currentPage;
    }

    public T CurrentPage { get; private set; }

    public LayoutModel Layout { get; set; }

    public IContent Section { get; set; }
}

public static class ProductViewModel
{
    /// <summary>
    /// Returns a PageViewModel of type <typeparam name="T"/>.
    /// </summary>
    /// <remarks>
    /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
    /// </remarks>
    public static ProductViewModel<T> Create<T>(T page)
        where T : ProductContent => new(page);
}
