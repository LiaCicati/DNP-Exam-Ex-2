using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Frontend.Models;

namespace Frontend.Data.Impl
{
    public class BookService : IBookService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient _client;

        public BookService()
        {
            _client = new HttpClient();
        }

        public async Task<IList<Book>> GetBooksAsync()
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(uri + "/books");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong");
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            List<Book> result = JsonSerializer.Deserialize<List<Book>>(message);
            return result;
        }

        public async Task AddBookAsync(int authorId, Book book)
        {
            StringContent content = new StringContent(
                JsonSerializer.Serialize(book),
                Encoding.UTF8,
                "application/json"
            );

            await _client.PostAsync(uri + "/books/" + authorId, content);
        }

        public async Task DeleteBookAsync(int isbn)
        {
            await _client.DeleteAsync(uri + "/books/" + isbn);
        }
    }
}