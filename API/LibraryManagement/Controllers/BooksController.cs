using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace LibraryManagement.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly IBooksRepository _booksRepository;
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _booksRepository.GetAlBooks());
        }

        [HttpGet("categories")]
        public async Task<ActionResult> GetBookCategories()
        {
            return Ok(await _booksRepository.GetBookCategories());
        }

        [HttpGet("status")]
        public async Task<ActionResult> GetBookStatus()
        {
            return Ok(await _booksRepository.GetBookStatus());
        }

        [HttpGet("type")]
        public async Task<ActionResult> GetBookType()
        {
            return Ok(await _booksRepository.GetBookTypes());
        }

        [HttpPost("createBook")]
        public async Task<ActionResult> CreateMasterBook([FromForm]BookMasterDto bookMasterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(bookMasterDto.BookImage == null || bookMasterDto.BookImage.Length < 1)
            {
                return BadRequest("The upload file is emppty.");
            }

            var ifBookExist = await _booksRepository.IfBookExist(bookMasterDto.Title, bookMasterDto.Author, bookMasterDto.Publisher);
            if (ifBookExist)
             return BadRequest("Book already exist");

            // Save FormFile
            var filePath = Path.Combine(@"ImagePath",bookMasterDto.BookImage.FileName);
            new FileInfo(filePath).Directory?.Create();
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await bookMasterDto.BookImage.CopyToAsync(stream);
            }

            var result = await _booksRepository.CreateMasterBook(bookMasterDto);
            return Ok(result);
        }

        [HttpPost("createBookISBN")]
        public async Task<ActionResult> CreateBookISBN(BookISBNDto bookISBNDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _booksRepository.CreateBookISBN(bookISBNDto);
            if (result == -1) return BadRequest("ISBN already exist.");
            return Ok(result);
        }

        [HttpGet("getmasterbooks")]
        public async Task<ActionResult> GetMasterBooks()
        {
            return Ok(await _booksRepository.GetMasterBook());
        }

        private  string UploadImage(string image)
        {
            return "";
        }
    }
}
