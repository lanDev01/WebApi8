using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.Dto.Book;
using WebApi8.Models;

namespace WebApi8.Services.Book
{
    public class BookService : IBookInterface
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context) 
        {
            _context = context;
        }

        // GET LIST BOOKS
        public async Task<ResponseModel<List<BookModel>>> ListBooks()
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books.Include(a => a.Author).ToListAsync();

                response.Dados = books;
                response.Message = "Todos os livros foram coletados!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        // CREATE BOOK
        public async Task<ResponseModel<List<BookModel>>> CreateBook(BookCreateDto bookCreateDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();

            try
            {
                var author = await _context.Authors
                    .FirstOrDefaultAsync(author => author.Id == bookCreateDto.Author.Id);

                if (author == null)
                {
                    response.Message = "Nenhum registro de autor localizado!";
                    return response;
                }

                var book = new BookModel()
                {
                    Title = bookCreateDto.Title,
                    Author = author
                };

                _context.Add(book);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Books.Include(a => a.Author).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        // GET BOOK BY ID
        public async Task<ResponseModel<BookModel>> GetBookById(int idBook)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {

                var book = await _context.Books
                    .Include(a => a.Author)
                    .FirstOrDefaultAsync(book => book.Id == idBook);

                if (book == null)
                {
                    response.Message = "Nenhum registro localizado!";
                    return response;
                }

                response.Dados = book;
                response.Message = "Livro Localizado com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        // GET BOOK BY ID AUTHORS
        public async Task<ResponseModel<List<BookModel>>> GetBookByIdAuthor(int idAuthor)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books
                    .Include(a => a.Author)
                    .Where(book => book.Author.Id == idAuthor)
                    .ToListAsync();

                if (book == null)
                {
                    response.Message = "Nenhum registro localizado!";
                    return response;
                }

                response.Dados = book;
                response.Message = "Livros localizados!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        // UPDATE BOOK
        public async Task<ResponseModel<List<BookModel>>> UpdateAuthor(BookUpdateDto bookUpdateDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();

            try
            {
                var book = await _context.Books
                    .Include(a => a.Author)
                    .FirstOrDefaultAsync(book => book.Id == bookUpdateDto.Id);

                var author = await _context.Authors
                    .FirstOrDefaultAsync(author => author.Id == bookUpdateDto.Author.Id);

                if (book == null)
                {
                    response.Message = "Nenhum registro de livro localizado!";
                    return response;
                }

                if (author == null)
                {
                    response.Message = "Nenhum registro de autor localizado!";
                    return response;
                }

                book.Title = bookUpdateDto.Title;
                book.Author = author;

                _context.Update(book);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Books.ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        // DELETAR BOOK
        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();

            try
            {
                var book = await _context.Books
                    .Include(a => a.Author)
                    .FirstOrDefaultAsync(book => book.Id == idBook);

                if (book == null)
                {
                    response.Message = "Nenhum livro localizado!";
                    return response;
                }

                _context.Remove(book);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Books.ToListAsync();
                response.Message = "Livro removido com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
