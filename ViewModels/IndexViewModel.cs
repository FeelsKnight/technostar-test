using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technostar_test.Models
{
    public class IndexViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public List<Product> Products { get; set; }
        public List<Person> Persons { get; set; }
    }
}
