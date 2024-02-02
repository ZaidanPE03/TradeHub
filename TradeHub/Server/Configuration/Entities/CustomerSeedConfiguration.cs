using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using TradeHub.Shared.Domain;

namespace TradeHub.Server.Configuration.Entities
{
    public class CustomerSeedConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                 new Customer
                 {
                     Id = 1,
                     Name = "Marry",
                     Contact = "123456",
                     Email = "Marry@Jane.com",
                     Address = "485 PasirRis Street 21"
                     

                 },
                 new Customer
                 {
                     Id = 2,
                     Name = "Kelly",
                     Contact = "326541",
                     Email = "Kelly@Low.com",
                     Address = "231 Tampines Street 12"

                 }
                );
        }
    }
}
