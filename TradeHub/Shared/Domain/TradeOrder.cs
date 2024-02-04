using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHub.Shared.Domain
{
    public class TradeOrder
    {
        public int Id { get; set; }
        
        public DateTime TradeDate { get; set; }
        public DateTime TradeTime { get; set; }
        public string? DeliveryMode { get; set; }
        public int? StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        [Required]
        public int? SellOrderId { get; set; }
        public virtual SellOrder? SellOrder { get; set; }
    }
}
