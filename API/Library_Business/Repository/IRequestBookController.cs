using Library_Business.Dtos;

namespace Library_Business.Repository
{
    public interface IRequestBookController
    {
        public Task<int> RequestBook(BookRequestDto bookRequestDto);

    }
}
