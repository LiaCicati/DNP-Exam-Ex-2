using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.DataAccess;
using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.Data.Impl
{
    public class AuthorRepository : IAuthorRepository
    {
        private AuthorDBContext _ctx;

        public AuthorRepository(AuthorDBContext context)
        {
            this._ctx = context;
        }

        public async Task<IList<Author>> GetAllAuthorsAsync()
        {
            return await _ctx.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _ctx.Authors.AddAsync(author);
            await _ctx.SaveChangesAsync();
            return author;
        }
    }
}