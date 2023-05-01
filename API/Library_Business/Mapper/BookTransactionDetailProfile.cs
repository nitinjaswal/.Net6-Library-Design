using AutoMapper;
using Library_Business.Dtos;
using Library_Data.Entities;

namespace Library_Business.Mapper
{
    public class BookTransactionDetailProfile:Profile
    {
        public BookTransactionDetailProfile()
        {
            CreateMap<BookTransactionDetail, BookTransactionDetailDto>();
        }
    }
}
