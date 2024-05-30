using WebApi8.Dto.Bond;

namespace WebApi8.Dto.Book
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public AuthorBondDto Author { get; set; }
    }
}
