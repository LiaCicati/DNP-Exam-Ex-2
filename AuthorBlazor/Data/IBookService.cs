using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Frontend.Models;

namespace Frontend.Data
{
    public interface IBookService
    {
        Task<IList<Book>> GetBooksAsync();
        Task AddBookAsync(int authorId, Book book);
        Task DeleteBookAsync(int isbn);
    }
}