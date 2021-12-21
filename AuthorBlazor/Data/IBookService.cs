using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBlazor.Models;


namespace AuthorBlazor.Data
{
    public interface IBookService
    {
        Task<IList<Book>> GetBooksAsync();
        Task AddBookAsync(int authorId, Book book);
        Task DeleteBookAsync(int isbn);
        Task<Book> GetBookByIsbnAsync(int isbn);
        Task<Book> UpdateBookAsync(Book book);
    }
}