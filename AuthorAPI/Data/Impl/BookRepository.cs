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
            Book toRemove = await _ctx.Books.FirstOrDefaultAsync(b => b.Isbn == isbn);
            if (toRemove != null)
            {
                _ctx.Remove(toRemove);
                await _ctx.SaveChangesAsync();
            }

            return toRemove;
        }

        public async Task<Book> GetBookByIsbnAsync(int isbn)
        {
          return await _ctx.Books.FirstAsync(b => b.Isbn == isbn);
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            try
            {
                Book toUpdate = await _ctx.Books.FirstAsync(b => b.Isbn == book.Isbn);
                // toUpdate = book;
                toUpdate.Title = book.Title;
                toUpdate.NumOfPages = book.NumOfPages;
                toUpdate.PublicationYear = book.PublicationYear;
                toUpdate.Genre = book.Genre;
                Console.WriteLine(toUpdate.Isbn + toUpdate.Title);
                _ctx.Update(toUpdate);
                await _ctx.SaveChangesAsync();
                return toUpdate;
            }
            catch (Exception e)
            {
                // throw new Exception($"Did not find todo with isbn {book.Isbn}");
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}