using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueBookController : BaseApiController
    {
        private readonly IIssueBookRepository _issueBookRepository;
        public IssueBookController(IIssueBookRepository issueBookRepository)
        {
            _issueBookRepository = issueBookRepository;
        }

        [HttpPost]
        public async Task<ActionResult> IssueBook(IssueBookDto issueBookDto)
        {
            return Ok(await _issueBookRepository.IssueBook(issueBookDto));
        }

        [HttpGet("UserBooksPosssessionCount")]
        public async Task<ActionResult> GetUserBooksPosssessionCount(int userId)
        {
            return Ok(await _issueBookRepository.UserBooksPosssessionCount(userId));
        }
    }
}
