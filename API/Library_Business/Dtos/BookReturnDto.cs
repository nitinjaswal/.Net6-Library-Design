using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Dtos
{
    public class BookReturnDto
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
