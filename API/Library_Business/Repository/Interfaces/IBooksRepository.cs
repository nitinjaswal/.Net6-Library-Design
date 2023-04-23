using Library_Business.Dtos;


namespace Library_Business.Repository.Interfaces
{
    public interface IBooksRepository
    {
        public Task<IEnumerable<BookDto>> GetAlBooks();
        public Task<IEnumerable<BookCategoryDto>> GetBookCategories();
        public Task<IEnumerable<BookStatusDto>> GetBookStatus();
        public Task<IEnumerable<BookTypeDto>> GetBookTypes();
        public Task<IEnumerable<MasterBookListDto>> GetMasterBook();
        public Task<BookDto> GetBookDetail(int masterBookId);
        public Task<IEnumerable<BookISBNDto>> GetISBNs();
    }
}
