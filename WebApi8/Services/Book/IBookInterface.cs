using WebApi8.Dto.Book;
using WebApi8.Models;

namespace WebApi8.Services.Book
{
    public interface IBookInterface
    {
        Task<ResponseModel<List<BookModel>>> ListBooks();
        Task<ResponseModel<BookModel>> GetBookById(int idBook);
        Task<ResponseModel<List<BookModel>>> GetBookByIdAuthor(int idAuthor);
        Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookCreateDto);
        Task<ResponseModel<List<BookModel>>> UpdateAuthor(BookUpdateDto bookUpdateDto);
        Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook);
    }
}
