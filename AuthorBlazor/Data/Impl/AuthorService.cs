using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AuthorBlazor.Models;


namespace AuthorBlazor.Data.Impl
{
    public class AuthorService : IAuthorService
    {
            private string uri = "https://localhost:5003";
            private readonly HttpClient _client;

        public AuthorService()
        {
            _client = new HttpClient();
        }

        public async Task<IList<Author>> GetAuthorsAsync()
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(uri + "/authors");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Something went wrong");
            }

            string message = await responseMessage.Content.ReadAsStringAsync();
            List<Author> result = JsonSerializer.Deserialize<List<Author>>(message);
            return result;
        }

        public async Task AddAuthorAsync(Author author)
        {
            string adultsAsJson = JsonSerializer.Serialize(author);
            HttpContent content = new StringContent(adultsAsJson, Encoding.UTF8, "application/json");
            await _client.PostAsync(uri + "/authors", content);
        }

        public async Task RemoveAuthorAsync(int authorId)
        {
            await _client.DeleteAsync($"{uri}/authors/{authorId}");
        }
    }
}