using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Frontend.Models;

namespace Frontend.Data
{
    public interface IAuthorService
    {
        Task<IList<Author>> GetAuthorsAsync();
        Task AddAuthorAsync(Author author);
        Task RemoveAuthorAsync(int authorId);
    }
}