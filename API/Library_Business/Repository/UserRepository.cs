using AutoMapper;
using Dapper;
using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data;
using Library_Data.Entities;
using System.Data;

namespace Library_Business.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateUser(User createUser)
        {
            try
            {
                var procedureName = "usp_CreateUser";
                var parameters = new DynamicParameters();
                parameters.Add("name", createUser.Name, DbType.String, ParameterDirection.Input);
                parameters.Add("email", createUser.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("passwordHash", createUser.PasswordHash, DbType.Binary, ParameterDirection.Input);
                parameters.Add("passwordSalt", createUser.PasswordSalt, DbType.Binary, ParameterDirection.Input);
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.ExecuteAsync
                       (procedureName, parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var procedureName = "usp_GetUserById";
            var parameters = new DynamicParameters();
            parameters.Add("Email", email, DbType.String, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<User>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return _mapper.Map<User, UserDto>(result);
            }
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var procedureName = "usp_GetAllUsers";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<User>
                    (procedureName, commandType: CommandType.StoredProcedure);
                return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(result);
            }
        }
    }
}
