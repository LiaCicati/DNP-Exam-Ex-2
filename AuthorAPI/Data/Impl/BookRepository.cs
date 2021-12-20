using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AuthorAPI.DataAccess;
using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.Data.Impl
{
    public class BookRepository : IBookRepository
    {
        private AuthorDBContext _ctx;

        public BookRepository(AuthorDBContext context)
        {
            this._ctx = context;
        }

        public async Task<IList<Book>> GetAllBooksAsync()
        {
            return await _ctx.Books.ToListAsync();
        }

        public async Task<Book> AddBookAsync(int authorId, Book book)
        {
            book.AuthorId = authorId;
            await _ctx.AddAsync(book);
            await _ctx.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBookAsync(int isbn)
        {
            Book toRemove = await _ctx.Books.FirstAsync(a => a.Isbn == isbn);
            Console.WriteLine(JsonSerializer.Serialize(toRemove));
            _ctx.Remove(toRemove);
            await _ctx.SaveChangesAsync();
            return toRemove;
        }
    }
}