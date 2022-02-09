using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public decimal Total { get; set; }

        public DateTime Date { get; set; }

        public List<OrderDetail> Items { get; set; }
    }
}
