using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BooksController: BaseApiController
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
        public async Task<ActionResult> CreateMasterBook([FromBody]BookMasterDto bookMasterDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
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
    }
}
