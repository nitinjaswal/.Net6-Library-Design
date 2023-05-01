using AutoMapper;
using Dapper;
using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data;
using Library_Data.Entities;
using System.Data;

namespace Library_Business.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<BookDto>> GetAlBooks()
        {
            var procedureName = "usp_GetAllBooks";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Book>
                    (procedureName, commandType: CommandType.StoredProcedure);
                return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(result);
            }
        }

        public async Task<IEnumerable<BookCategoryDto>> GetBookCategories()
        {
            var procedureName = "usp_GetBookCategory";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<BookCategory>
                    (procedureName, commandType: CommandType.StoredProcedure);
                return _mapper.Map<IEnumerable<BookCategory>, IEnumerable<BookCategoryDto>>(result);
            }
        }

        public async Task<BookDto> GetBookDetail(int masterBookId)
        {
            var procedureName = "usp_GetBookDetail";
            var paramter = new DynamicParameters();
            paramter.Add("masterBookId", masterBookId, DbType.Int64, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<Book>
                    (procedureName,paramter, commandType: CommandType.StoredProcedure);
                return _mapper.Map<Book, BookDto>(result);
            }
        }

        public async Task<IEnumerable<BookStatusDto>> GetBookStatus()
        {
            var procedureName = "usp_GetStatus";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<BookStatus>
                    (procedureName, commandType: CommandType.StoredProcedure);
                return _mapper.Map<IEnumerable<BookStatus>, IEnumerable<BookStatusDto>>(result);
            }
        }

        public async Task<IEnumerable<BookTypeDto>> GetBookTypes()
        {
            var procedureName = "usp_GetBookTypes";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<BookType>
                    (procedureName, commandType: CommandType.StoredProcedure);
                return _mapper.Map<IEnumerable<BookType>, IEnumerable<BookTypeDto>>(result);
            }
        }

        public async Task<IEnumerable<MasterBookListDto>> GetMasterBook()
        {
            var procedureName = "usp_GetMasterBook";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<MasterBookListDto>(procedureName, commandType: CommandType.StoredProcedure);
                return result;
                // return _mapper.Map<IEnumerable<MasterBookListDto>, IEnumerable<MasterBookListDto>>(result);
            }
        }

        public async Task<IEnumerable<BookISBNDto>> GetISBNs()
        {
            var procedureName = "usp_GetISBNs";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<BookISBN>
                    (procedureName, commandType: CommandType.StoredProcedure);
                return _mapper.Map<IEnumerable<BookISBN>, IEnumerable<BookISBNDto>>(result);
            }
        }
    }
}
