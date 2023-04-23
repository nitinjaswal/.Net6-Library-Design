using Library_Business.Dtos;
using Library_Business.Repository;
using Library_Business.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnBookController : BaseApiController
    {
        private readonly IReturnBookRepository _returnBookRepository;
        public ReturnBookController(IReturnBookRepository returnBookRepository)
        {
            _returnBookRepository= returnBookRepository;
        }

        // GET: api/<ReturnBookController>
        [HttpGet("CheckBookFine")]
        public async Task<ActionResult> Get(string ISBN)
        {
            return Ok(await _returnBookRepository.CheckIfFineExist(ISBN));
        }

       
        // POST api/<ReturnBookController>
        [HttpPost("returnBook")]
        public async Task<ActionResult> Post(BookReturnDto bookReturnDto)
        {
           return Ok( _returnBookRepository.ReturnBook(bookReturnDto.UserId, bookReturnDto.ISBN));
        }
    }
}
