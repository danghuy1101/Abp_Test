using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.Bookstore.Books
{
    public class Book : AuditedEntity<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
        public Guid AuthorId { get; set; }

    }
}
