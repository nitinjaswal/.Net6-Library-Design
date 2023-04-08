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

        public async Task<int> CreateBookISBN(BookISBNDto bookISBNDto)
        {
            var procedureName = "usp_AddBookISBN";
            var parameters = new DynamicParameters();
            parameters.Add("ISBN", bookISBNDto.ISBN, DbType.String, ParameterDirection.Input);
            parameters.Add("@IsActive", 1, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("@StatusId", bookISBNDto.BookStatus, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@CreatedDateTime", DateTime.Now, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@UpdatedDateTime", DateTime.Now, DbType.DateTime2, ParameterDirection.Input);
            parameters.Add("@BookMasterId", bookISBNDto.MasterBook, DbType.Int64, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                int result = connection.ExecuteScalar<int>
                   (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> CreateMasterBook(BookMasterDto bookMasterDto)
        {
            try
            {
                var procedureName = "usp_AddBookmaster";
                var parameters = new DynamicParameters();
                parameters.Add("Title", bookMasterDto.Title, DbType.String, ParameterDirection.Input);
                parameters.Add("Publisher", bookMasterDto.Publisher, DbType.String, ParameterDirection.Input);
                parameters.Add("Author", bookMasterDto.Author, DbType.String, ParameterDirection.Input);
                parameters.Add("TotalPages", bookMasterDto.TotalPages, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Description", bookMasterDto.Description, DbType.String, ParameterDirection.Input);
                parameters.Add("ImagePath", @"ImagePath/" + bookMasterDto.BookImage.FileName, DbType.String, ParameterDirection.Input);
                parameters.Add("BookTypeId", bookMasterDto.BookType, DbType.Int64, ParameterDirection.Input);
                parameters.Add("BookCategoryId", bookMasterDto.BookCategory, DbType.Int64, ParameterDirection.Input);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync
                       (procedureName, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
  
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

        public async Task<bool> IfBookExist(string title, string author, string publisher)
        {
            var procedureName = "usp_IfBookExist";
            var parameters = new DynamicParameters();
            parameters.Add("Title", title, DbType.String, ParameterDirection.Input);
            parameters.Add("Publisher", publisher, DbType.String, ParameterDirection.Input);
            parameters.Add("Author", author, DbType.String, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var result = connection.ExecuteScalar(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return Convert.ToBoolean(result);
            }
        }

        public async Task<int> IssueBook(IssueBookDto issueBookDto)
        {
            var procedureName = "usp_IssueBook";
            var parameters = new DynamicParameters();
            parameters.Add("UserId",issueBookDto.UserId,DbType.Int64,ParameterDirection.Input);
            parameters.Add("BookISBN", issueBookDto.ISBN, DbType.String, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> RequestBook(BookRequestDto bookRequestDto)
        {
            var procedureName = "usp_RequestBook";
            var parameters = new DynamicParameters();
            parameters.Add("ISBN", bookRequestDto.ISBN, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", bookRequestDto.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("RequestStatus", bookRequestDto.RequestStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("IsOnlineRequest", 1, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("CreatedDateTime", DateTime.Now, DbType.DateTime2, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
