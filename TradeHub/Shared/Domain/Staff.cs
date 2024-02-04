using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeHub.Shared.Domain
{
    public class Staff
    {
        public int Id { get; set; }
		[Required]
		[DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
		public string? Name { get; set; }
		[Required]
		[RegularExpression(@"^\d{8}$", ErrorMessage = "Invalid contact number.")]
		public string? Contact { get; set; }
		[Required]
		[DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
		public string? Email { get; set; }
        public string? Role { get; set; }



    }
}
