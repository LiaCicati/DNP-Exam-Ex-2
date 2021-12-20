using System.ComponentModel.DataAnnotations;

namespace AuthorAPI.Models
{
    public class Book
    {
        [Key] public int Isbn { get; set; }

        [Required(ErrorMessage = "Title is required"), MaxLength(40)]
        public string Title { get; set; }

        public int PublicationYear { get; set; }
        public int NumOfPages { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
    }
}