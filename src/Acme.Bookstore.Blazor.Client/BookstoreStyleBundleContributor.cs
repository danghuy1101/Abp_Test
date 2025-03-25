using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Acme.Bookstore.Blazor.Client;

public class BookstoreStyleBundleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add(new BundleFile("main.css", true));
    }
}
