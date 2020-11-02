using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technostar_test.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public string Type { get; set; }
        public string? Model { get; set; }
    }
}
