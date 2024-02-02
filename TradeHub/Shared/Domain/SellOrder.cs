using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHub.Shared.Domain
{
    public class SellOrder
    {
        public int Id { get; set; }
        public DateTime SellDate { get; set; }
        public DateTime SellTime { get; set; }
        public string? DeliveryMode { get; set; }
        public int StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
