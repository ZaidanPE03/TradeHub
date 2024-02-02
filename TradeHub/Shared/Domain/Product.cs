using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHub.Shared.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public int TradeId { get; set; }
        public virtual TradeOrder? TradeOrder { get; set; }
        public int SellId { get; set; }
        public virtual SellOrder? SellOrder { get; set; }


    }
}
