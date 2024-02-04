using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHub.Shared.Domain
{
    public class Product
    {
        public int Id { get; set; }
		[Required]

		[StringLength(100, MinimumLength = 5, ErrorMessage = " Name does not meet length requirements")]
		public string? Name { get; set; }

		[Required]

		[StringLength(100, MinimumLength = 5, ErrorMessage = " Name does not meet length requirements")]
		public string? Description { get; set; }

		[Required]

		[StringLength(100, MinimumLength = 1, ErrorMessage = " Name does not meet length requirements")]
		public string? Type { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }

        public int TradeId { get; set; }
        public virtual TradeOrder? TradeOrder { get; set; }
        public int SellId { get; set; }
        public virtual SellOrder? SellOrder { get; set; }


    }
}
