using AutoMapper;
using Library_Business.Dtos;
using Library_Data.Entities;

namespace Library_Business.Mapper
{
    public class BookISBNProfile:Profile
    {
        public BookISBNProfile()
        {
            CreateMap<BookISBN, BookISBNDto>();
        }
    }
}
