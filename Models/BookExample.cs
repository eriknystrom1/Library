using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookExample
    {
        [Key]
        public int? Id { get; set; }
        public string Borrowed { get; set; }

        public  Book Book { get; set; }
    }
}
