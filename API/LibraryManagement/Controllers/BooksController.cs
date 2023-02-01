using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data.Entities;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult> CreateMasterBook(BookMasterDto bookMasterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ifBookExist = await _booksRepository.IfBookExist(bookMasterDto.Title, bookMasterDto.Author, bookMasterDto.Publisher);
            if (ifBookExist)
                return BadRequest("Book already exist");
   
                   var result = await _booksRepository.CreateMasterBook(bookMasterDto);
            return Ok(result);
        }

        [HttpPost("createBookISBN")]
        public async Task<ActionResult> CreateBookISBN([FromBody] BookISBNDto bookISBNDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _booksRepository.CreateBookISBN(bookISBNDto);
            return Ok(result);
        }

        private  string UploadImage(string image)
        {
            return "";
        }
    }
}
