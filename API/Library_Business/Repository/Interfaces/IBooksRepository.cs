using Library_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Repository.Interfaces
{
    public interface IBooksRepository
    {
        public Task<IEnumerable<Book>> GetAlBooks();
    }
}
