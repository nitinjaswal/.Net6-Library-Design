using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class GetBooksController : BaseApiController
    {
        private readonly IBooksRepository _booksRepository;
        public GetBooksController(IBooksRepository booksRepository)
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

        [HttpGet("getmasterbooks")]
        public async Task<ActionResult> GetMasterBooks()
        {
            return Ok(await _booksRepository.GetMasterBook());
        }

        [HttpGet("bookdetail")]
        public async Task<ActionResult> GetBookDetail(int bookMasterId)
        {
            return Ok(await _booksRepository.GetBookDetail(bookMasterId));
        }

    }
}
