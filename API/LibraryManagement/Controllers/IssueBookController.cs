using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueBookController : BaseApiController
    {
        private readonly IBooksRepository _booksRepository;
        public IssueBookController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpPost]
        public async Task<ActionResult> IssueBook(IssueBookDto issueBookDto)
        {
            return Ok(await _booksRepository.IssueBook(issueBookDto));
        }

        
    }
}
