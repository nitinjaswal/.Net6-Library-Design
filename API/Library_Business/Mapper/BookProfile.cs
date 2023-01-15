using AutoMapper;
using Library_Business.Dtos;
using Library_Data.Entities;


namespace Library_Business.Mapper
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
