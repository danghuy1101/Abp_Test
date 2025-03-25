using Acme.BookStore.Authors;
using AutoMapper;

namespace Acme.Bookstore.Blazor.Client;

public class BookstoreBlazorAutoMapperProfile : Profile
{
    public BookstoreBlazorAutoMapperProfile()
    {
        CreateMap<AuthorDto, UpdateAuthorDto>();

        //Define your AutoMapper configuration here for the Blazor project.
    }
}