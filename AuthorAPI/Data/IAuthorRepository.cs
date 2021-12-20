using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Models;

namespace AuthorAPI.Data
{
    public interface IAuthorRepository
    {
        Task<IList<Author>> GetAllAuthorsAsync();
        Task<Author> AddAuthorAsync(Author author);
    }
}