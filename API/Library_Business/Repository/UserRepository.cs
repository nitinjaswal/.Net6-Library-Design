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

        public async Task CreateUser(CreateUserDto createUserDto)
        {
            var procedureName = "usp_CreateUser";
            var parameters = new DynamicParameters();
            parameters.Add("name", createUserDto.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("email", createUserDto.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("password", createUserDto.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("phone", createUserDto.Phone, DbType.String, ParameterDirection.Input);
            parameters.Add("isActive", createUserDto.IsActive, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("role", createUserDto.Role, DbType.String, ParameterDirection.Input);
            parameters.Add("createdDateTime", DateTime.Now, DbType.String, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync
                   (procedureName, parameters, commandType: CommandType.StoredProcedure);
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
