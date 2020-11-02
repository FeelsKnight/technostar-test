using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace technostar_test.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal UsdAmount { get; set; }
    }
}
