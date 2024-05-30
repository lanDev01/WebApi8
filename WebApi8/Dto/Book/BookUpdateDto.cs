using WebApi8.Dto.Bond;

namespace WebApi8.Dto.Book
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorBondDto Author { get; set; }
    }
}
