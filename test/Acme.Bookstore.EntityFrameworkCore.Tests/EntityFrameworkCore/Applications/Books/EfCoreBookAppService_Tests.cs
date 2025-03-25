using Acme.Bookstore.EntityFrameworkCore;
using Acme.Bookstore;
using Acme.BookStore.Books;
using Xunit;

namespace Acme.BookStore.EntityFrameworkCore.Applications.Books;

[Collection(BookstoreTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<BookstoreEntityFrameworkCoreTestModule>
{

}
