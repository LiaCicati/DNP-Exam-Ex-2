using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBlazor.Models;


namespace AuthorBlazor.Data
{
    public interface IAuthorService
    {
        Task<IList<Author>> GetAuthorsAsync();
        Task AddAuthorAsync(Author author);
        Task RemoveAuthorAsync(int authorId);
    }
}