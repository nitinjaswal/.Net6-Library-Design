using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Dtos
{
    public class BookRequestDto
    {
        public string ISBN { get; set; }
        public int  UserId { get; set; }
        public string RequestStatus { get; set; }
        public bool IsOnlineRequest { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
