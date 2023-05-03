using Library_Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Repository.Interfaces
{
    public interface IReturnBookRepository
    {
        public Task<BookTransactionDetailDto> GetBookTransactionDetail(string ISBN);
        public Task<int> ReturnBook(string ISBN);
    }
}
