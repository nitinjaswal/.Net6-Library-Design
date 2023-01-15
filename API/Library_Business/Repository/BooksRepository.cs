using AutoMapper;
using Dapper;
using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data;
using Library_Data.Entities;
using System.Data;

namespace Library_Business.Repository
{
    public class BooksRepository: IBooksRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(AppDbContext context, IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
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
    }
}
