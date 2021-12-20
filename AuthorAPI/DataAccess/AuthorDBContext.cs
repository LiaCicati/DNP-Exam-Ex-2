using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.DataAccess
{
    public class AuthorDBContext :DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                @"Data Source = C:\Users\Lia Cicati\EXAMS-3-Semester\DNP\Exams\DNP-Exam-Ex-2\AuthorAPI\AuthorDB.db");
        }
    }
}