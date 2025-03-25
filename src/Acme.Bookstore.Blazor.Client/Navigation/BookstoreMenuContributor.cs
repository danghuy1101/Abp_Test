using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Acme.Bookstore.Localization;
using Acme.Bookstore.Permissions;
using Acme.Bookstore.MultiTenancy;
using Volo.Abp.Account.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.Users;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.Identity.Blazor;

namespace Acme.Bookstore.Blazor.Client.Navigation;

public class BookstoreMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public BookstoreMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BookstoreResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                "BookStore.Home",
                l["Menu:Home"],
                "/",
                icon: "fas fa-home"
            )
        );

        context.Menu.AddItem(new ApplicationMenuItem(
            "BooksStore.Authors",
            l["Menu:Authors"],
            url: "/authors"
        ).RequirePermissions(BookstorePermissions.Books.Default));


        var bookStoreMenu = new ApplicationMenuItem(
            "BooksStore",
            l["Menu:BookStore"],
            icon: "fa fa-book"
        );

        context.Menu.AddItem(bookStoreMenu);

        bookStoreMenu.AddItem(new ApplicationMenuItem(
            "BooksStore.Books",
            l["Menu:Books"],
            url: "/books"
        ).RequirePermissions(BookstorePermissions.Books.Default));
        return Task.CompletedTask;
    }


    private async Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var accountStringLocalizer = context.GetLocalizer<AccountResource>();
        var authServerUrl = _configuration["AuthServer:Authority"] ?? "";

        // Add account management item for authenticated users
        context.Menu.AddItem(new ApplicationMenuItem(
            "Account.Manage",
            accountStringLocalizer["MyAccount"],
            $"{authServerUrl.EnsureEndsWith('/')}Account/Manage",
            icon: "fa fa-cog",
            order: 1000,
            target: "_blank").RequireAuthenticated());

        await Task.CompletedTask;
    }
}
