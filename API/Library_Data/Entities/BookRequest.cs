using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Data.Entities
{
    public class BookRequest
    {
        public int Id { get; set; }

        public User UserId { get; set; }
        public string RequestStatus { get; set; }
    }
}
