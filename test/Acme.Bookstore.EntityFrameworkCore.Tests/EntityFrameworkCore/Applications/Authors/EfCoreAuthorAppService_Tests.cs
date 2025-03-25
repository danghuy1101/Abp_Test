using Acme.Bookstore.EntityFrameworkCore;
using Acme.Bookstore;
using Acme.BookStore.Authors;
using Xunit;

namespace Acme.BookStore.EntityFrameworkCore.Applications.Authors;

[Collection(BookstoreTestConsts.CollectionDefinitionName)]
public class EfCoreAuthorAppService_Tests : AuthorAppService_Tests<BookstoreEntityFrameworkCoreTestModule>
{

}
