using Microsoft.AspNetCore.Mvc;
using WebApi8.Dto.Book;
using WebApi8.Models;
using WebApi8.Services.Book;

namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;

        public BookController(IBookInterface bookInterface)
        {
            _bookInterface = bookInterface;
        }

        [HttpGet("ListBooks")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListBooks()
        {
            var books = await _bookInterface.ListBooks();
            return Ok(books);
        }

        [HttpGet("GetBookById/{idBook}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById(int idBook)
        {
            var author = await _bookInterface.GetBookById(idBook);
            return Ok(author);
        }

        [HttpGet("GetBookByIdAuthor/{idAuthor}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookByIdAuthor(int idAuthor)
        {
            var book = await _bookInterface.GetBookByIdAuthor(idAuthor);
            return Ok(book);
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(BookCreateDto bookCreateDto)
        {
            var books = await _bookInterface.CreateBook(bookCreateDto);
            return Ok(books);
        }

        [HttpPut("UpdateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> UpdateAuthor(BookUpdateDto bookUpdateDto)
        {
            var books = await _bookInterface.UpdateAuthor(bookUpdateDto);
            return Ok(books);
        }

        [HttpDelete("DeleteBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int idBook)
        {
            var books = await _bookInterface.DeleteBook(idBook);
            return Ok(books);
        }
    }
}
