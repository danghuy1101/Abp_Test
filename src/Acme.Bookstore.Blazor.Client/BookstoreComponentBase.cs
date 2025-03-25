using Acme.Bookstore.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Acme.Bookstore.Blazor.Client;

public abstract class BookstoreComponentBase : AbpComponentBase
{
    protected BookstoreComponentBase()
    {
        LocalizationResource = typeof(BookstoreResource);
    }
}
