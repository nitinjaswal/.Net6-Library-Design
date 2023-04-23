using AutoMapper;
using Dapper;
using Library_Business.Repository.Interfaces;
using Library_Data;
using System.Data;

namespace Library_Business.Repository
{
    public class ReturnBookRepository : IReturnBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ReturnBookRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CheckIfFineExist(string ISBN)
        {
            var procedureName = "usp_CheckUserFine";
            var parameters = new DynamicParameters();
            parameters.Add("BookISBN", ISBN, DbType.String, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var result =  connection.ExecuteScalar(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return Convert.ToBoolean(result);
            }
        }

        public async Task ReturnBook(int UserId, string ISBN)
        {
            var procedureName = "usp_ReturnBook";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BookISBN", ISBN, DbType.String, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
