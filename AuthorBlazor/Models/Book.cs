using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuthorBlazor.Models
{
    public class Book
    {
        [JsonPropertyName("isbn")] public int Isbn { get; set; }

        [Required(ErrorMessage = "Title Field is Required")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publication Year Field is Required")]
        [JsonPropertyName("publicationYear")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Nr of pages Field is Required")]
        [JsonPropertyName("numOfPages")]
        public int NrOfPages { get; set; }

        [Required(ErrorMessage = "Genre Field is Required")]
        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("authorId")] public int AuthorId { get; set; }
    }
}