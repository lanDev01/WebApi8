using WebApi8.Dto.Author;
using WebApi8.Models;

namespace WebApi8.Services.Author
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> GetAuthorByIdBook(int idBook);
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto);
        Task<ResponseModel<List<AuthorModel>>> UpdateAuthor(AuthorUpdateDto authorUpdateDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor);
    }
}
