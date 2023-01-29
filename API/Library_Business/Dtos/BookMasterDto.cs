using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Dtos
{
    public class BookMasterDto
    {

        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Publisher { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageFolderPath { get; set; }
        [Required]
        public int BookTypeId { get; set; }
        [Required]
        public int BookCategoryId { get; set; }
    }
}
