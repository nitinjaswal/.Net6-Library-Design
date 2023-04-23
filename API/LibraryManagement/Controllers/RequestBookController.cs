using Library_Business.Dtos;
using Library_Business.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestBookController : BaseApiController
    {
        private readonly IRequestBookController _requestBookController;
        public RequestBookController(IRequestBookController requestBookController)
        {
            _requestBookController = requestBookController;
        }

        [HttpPost("requestbook")]
        public async Task<ActionResult> RequestBook([FromBody] BookRequestDto bookRequestDto)
        {
            return Ok(await _requestBookController.RequestBook(bookRequestDto));
        }
    }
}
