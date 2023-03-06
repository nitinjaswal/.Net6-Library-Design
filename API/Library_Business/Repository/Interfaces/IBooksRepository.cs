using Library_Business.Dtos;


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
        public Task<bool> IfBookExist(string title, string author, string publisher);
        public Task<IEnumerable<MasterBookListDto>> GetMasterBook();
        public Task<BookDto> GetBookDetail(int masterBookId);

        public Task RequestBook(BookRequestDto bookRequestDto);

        public Task<int> IssueBook(IssueBookDto issueBookDto);
    }
}
