using Library_Business.Dtos;
using Library_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Repository.Interfaces
{
    public interface IBooksRepository
    {
        public Task<IEnumerable<BookDto>> GetAlBooks();
        public Task<int> CreateMasterBook(BookMasterDto bookMasterDto);
        public Task<int> CreateBookISBN(BookISBNDto bookISBNDto);
        public Task<IEnumerable<BookCategoryDto>> GetBookCategories();
        public Task<IEnumerable<BookStatusDto>> GetBookStatus();
        public Task<IEnumerable<BookTypeDto>> GetBookTypes();
    }
}
