using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHub.Shared.Domain
{
    public class SellOrder
    {
        public int Id { get; set; }
        [Required]
        public DateTime SellDate { get; set; }
        [Required]
        public DateTime SellTime { get; set; }
        [Required]
        public string? DeliveryMode { get; set; }
        public int? StaffId { get; set; }
        public virtual Staff? Staff { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        [Required]
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set;}
      
    }
}
