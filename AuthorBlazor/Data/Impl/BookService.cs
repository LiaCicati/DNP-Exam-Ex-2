using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AuthorBlazor.Models;


namespace AuthorBlazor.Data.Impl
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
            HttpResponseMessage response = await _client.GetAsync(uri + "/books");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<Book> result = JsonSerializer.Deserialize<List<Book>>(message);
            return result;
        }

        public async Task AddBookAsync(int authorId, Book book)
        {
            string booksAsJson = JsonSerializer.Serialize(book);
            HttpContent content = new StringContent(booksAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await _client.PostAsync(uri + "/books/" + authorId, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task DeleteBookAsync(int isbn)
        {
            HttpResponseMessage response = await _client.DeleteAsync(uri + "/books/" + isbn);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task<Book> GetBookByIsbnAsync(int isbn)
        {
            HttpResponseMessage response = await _client.GetAsync(uri + "/books/" + isbn);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            Book result = JsonSerializer.Deserialize<Book>(message);
            return result;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            string booksAsJson = JsonSerializer.Serialize(book);
            HttpContent content = new StringContent(booksAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await _client.PatchAsync($"{uri}/books/{book.Isbn}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            return book;
        }
    }
}