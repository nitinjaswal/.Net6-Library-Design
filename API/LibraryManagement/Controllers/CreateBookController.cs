using Library_Business.Dtos;
using Library_Business.Repository;
using Library_Business.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class CreateBookController : BaseApiController
    {
        private readonly ICreateBookRepository _createBookRepository;
        public CreateBookController(ICreateBookRepository createBookRepository)
        {
            this._createBookRepository = createBookRepository;
        }

        [HttpPost("masterBook")]
        public async Task<ActionResult> CreateMasterBook([FromForm] BookMasterDto bookMasterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (bookMasterDto.BookImage == null || bookMasterDto.BookImage.Length < 1)
            {
                return BadRequest("The upload file is emppty.");
            }

            var ifBookExist = await _createBookRepository.IfBookExist(bookMasterDto?.Title, bookMasterDto.Author, bookMasterDto.Publisher);
            if (ifBookExist)
                return BadRequest("Book already exist");

            // Save FormFile
            var filePath = Path.Combine(@"ImagePath" + '/', bookMasterDto.BookImage.FileName);
            new FileInfo(filePath).Directory?.Create();
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await bookMasterDto.BookImage.CopyToAsync(stream);
            }

            var result = await _createBookRepository.CreateMasterBook(bookMasterDto);
            return Ok(result);
        }

        [HttpPost("ISBN")]
        public async Task<ActionResult> CreateBookISBN(BookISBNDto bookISBNDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _createBookRepository.CreateBookISBN(bookISBNDto);
            if (result == -1) return BadRequest("ISBN already exist.");
            return Ok(result);
        }
    }
}
