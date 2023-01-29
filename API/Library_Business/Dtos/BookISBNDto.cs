using System.ComponentModel.DataAnnotations;

namespace Library_Business.Dtos
{
    public class BookISBNDto
    {
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int BookStatusId { get; set; }
        [Required]
        public int MasterBookId { get; set; }
    }
}
