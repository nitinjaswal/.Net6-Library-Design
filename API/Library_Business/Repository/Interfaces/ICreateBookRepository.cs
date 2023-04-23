using Library_Business.Dtos;

namespace Library_Business.Repository.Interfaces
{
    public interface ICreateBookRepository
    {
        public Task<int> CreateMasterBook(BookMasterDto bookMasterDto);
        public Task<int> CreateBookISBN(BookISBNDto bookISBNDto);
        public Task<bool> IfBookExist(string title, string author, string publisher);
    }
}
