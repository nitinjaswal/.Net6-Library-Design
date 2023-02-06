using Microsoft.AspNetCore.Http;
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
        public string? Author { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? ImageFolderPath { get; set; }
        [Required]
        public int BookType { get; set; }
        [Required]
        public int BookCategory { get; set; }
        [Required]
        public IFormFile BookImage { get; set; }
    }

    public class FileToUpload
    {
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public long LastModifiedTime { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string FileAsBase64 { get; set; }
        public byte[] FileAsByteArray { get; set; }
    }
}
