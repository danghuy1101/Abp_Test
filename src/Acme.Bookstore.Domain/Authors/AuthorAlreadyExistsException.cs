using Acme.Bookstore;
using Volo.Abp;

namespace Acme.BookStore.Authors;

public class AuthorAlreadyExistsException : BusinessException
{
    public AuthorAlreadyExistsException(string name)
        : base(BookstoreDomainErrorCodes.AuthorAlreadyExists)
    {
        WithData("name", name);
    }
}
