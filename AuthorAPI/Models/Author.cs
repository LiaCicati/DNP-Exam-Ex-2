using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthorAPI.Models
{
    public class Author
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required"), MaxLength(15)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required"), MaxLength(15)]
        public string LastName { get; set; }

        public IList<Book> Books { get; set; }
    }
}