using AutoMapper;
using Dapper;
using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data;
using Library_Data.Entities;
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

        public async Task<BookTransactionDetailDto> GetBookTransactionDetail(string ISBN)
        {
            var procedureName = "usp_BookTransactionDetail";
            var parameters = new DynamicParameters();
            parameters.Add("ISBN", ISBN, DbType.String, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<BookTransactionDetail>
                   (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return _mapper.Map<BookTransactionDetail,BookTransactionDetailDto>(result);
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
