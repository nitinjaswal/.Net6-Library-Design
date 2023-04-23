using AutoMapper;
using Dapper;
using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data;
using System.Data;

namespace Library_Business.Repository
{
    public class CreateBookRepository : ICreateBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookRepository(AppDbContext context, IMapper mapper)
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
            catch (Exception ex)
            {
                throw ex;
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

    }
}
