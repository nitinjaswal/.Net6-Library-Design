using Library_Business.Dtos;

namespace Library_Business.Repository.Interfaces
{
    public interface IIssueBookRepository
    {
        public Task<int> IssueBook(IssueBookDto issueBookDto);

        public Task<int> UserBooksPosssessionCount(int UserId);
    }
}
