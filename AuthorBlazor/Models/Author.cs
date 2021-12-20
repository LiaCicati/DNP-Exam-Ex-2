using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Frontend.Models
{
    public class Author
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [Required(ErrorMessage = "First Name Field is Required")]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [Required(ErrorMessage = "Last Name Field is Required")]
        public string LastName { get; set; }
        [JsonPropertyName("books")]

        public List<Book> Books { get; set; }
    }
}