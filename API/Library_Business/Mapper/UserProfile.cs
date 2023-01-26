using AutoMapper;
using Library_Business.Dtos;
using Library_Data.Entities;

namespace Library_Business.Mapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
