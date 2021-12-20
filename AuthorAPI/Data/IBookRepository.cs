using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Models;

namespace AuthorAPI.Data.Impl
{
    public interface IBookRepository
    {
        Task<IList<Book>> GetAllBooksAsync();
        Task<Book> AddBookAsync(int authorId, Book book);
        Task<Book> DeleteBookAsync(int isbn);
    }
}