using EPiServer.Framework;
using EPiServer.Commerce.Routing;
using EPiServer.Framework.Initialization;

namespace CmsCommerce.Infrastructure;

[InitializableModule]
[ModuleDependency(typeof(EPiServer.Commerce.Initialization.InitializationModule))]
public class SiteInitialization : IInitializableModule
{
    public void Initialize(InitializationEngine context) => CatalogRouteHelper.MapDefaultHierarchialRouter(false);

    // This way works too for more complex initialization logic
    // public void Initialize(InitializationEngine context)
    // {
    //     CatalogRouteHelper.MapDefaultHierarchialRouter(false);
    // }

    public void Uninitialize(InitializationEngine context)
    {
        // Add uninitialization logic
    }

    public void Preload(string[] parameters)
    {
        // Add preload logic. This method is called once during application startup and before the application is initialized
    }
}