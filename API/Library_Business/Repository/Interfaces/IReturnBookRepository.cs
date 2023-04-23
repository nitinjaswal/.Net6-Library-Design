using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Repository.Interfaces
{
    public interface IReturnBookRepository
    {
        public Task<bool> CheckIfFineExist(string ISBN);
        public Task ReturnBook(int UserId, string ISBN);
    }
}
