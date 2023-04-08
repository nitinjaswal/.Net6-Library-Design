using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestBookController : BaseApiController
    {
        private readonly IBooksRepository _booksRepository;
        public RequestBookController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpPost("requestbook")]
        public async Task<ActionResult> RequestBook([FromBody] BookRequestDto bookRequestDto)
        {
            return Ok(await _booksRepository.RequestBook(bookRequestDto));
        }
    }
}
