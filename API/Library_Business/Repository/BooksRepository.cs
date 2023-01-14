using Dapper;
using Library_Business.Repository.Interfaces;
using Library_Data;
using Library_Data.Entities;
using System.Data;

namespace Library_Business.Repository
{
    public class BooksRepository: IBooksRepository
    {
        private readonly AppDbContext _context;

        public BooksRepository(AppDbContext context)
        {
            _context= context;
        }

        public async Task<IEnumerable<Book>> GetAlBooks()
        {
            var procedureName = "usp_GetAllBooks";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Book>
                    (procedureName, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
