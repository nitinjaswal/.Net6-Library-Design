using Dapper;
using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data;
using System.Data;

namespace Library_Business.Repository
{
    public class IssueBookRepository : IIssueBookRepository
    {
        private readonly AppDbContext _context;

        public IssueBookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> IssueBook(IssueBookDto issueBookDto)
        {
            var procedureName = "usp_IssueBook";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", issueBookDto.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BookISBN", issueBookDto.ISBN, DbType.String, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UserBooksPosssessionCount(int UserId)
        {
            var procedureName = "usp_CheckTotalBookIssuedToUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", UserId, DbType.Int64, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteScalarAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return (int)result;
            }
        }
    }
}
