using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.Models;

namespace WebApi8.Services.Author
{
    public class AuthorServices : IAuthorInterface
    {
        private readonly AppDbContext _context;

        public AuthorServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {

                var author = await _context.Authors.FirstOrDefaultAsync(authorBank => authorBank.Id == idAuthor);

                if (author == null)
                {
                    response.Message = "Nenhum registro localizado!";
                    return response;
                }

                response.Dados = author;
                response.Message = "Autor Localizado!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
            
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByIdBook(int idBook)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
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

                response.Dados = book.Author;
                response.Message = "Autor localizado!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> ListAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var authors = await _context.Authors.ToListAsync();

                response.Dados = authors;
                response.Message = "Todos os autores foram coletados!";

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
