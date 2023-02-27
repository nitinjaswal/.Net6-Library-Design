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
        public int Id { get; set; }
        public int BookCount { get; set; }

        public string? Title { get; set; }
        public string? Publisher { get; set; }
        public string? AuthorName { get; set; }
        public int TotalPages { get; set; }
        public string? Description { get; set; }
        public string? BookType { get; set; }
        public string? Category { get; set; }
        public string? Status { get; set; }    
        public string? ImagePath { get; set; }
        public string ISBN { get; set; }
    }
}
