using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookUser
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public  User User { get; set; }
        public Book Book { get; set; }

             public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }


    }
}
