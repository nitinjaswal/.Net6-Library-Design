using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string AuthorName { get; set; }
        public int TotalPages { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public BookCategory Book_CategoryId { get; set; }
    }
}
