using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using TradeHub.Shared.Domain;

namespace TradeHub.Server.Configuration.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                 new Staff
                 {
                     Id = 1,
                     Name = "John",
                     Contact = "123",
                     Email = "John@Doe.com",
                     

                 },
                 new Staff
                 {
                     Id = 2,
                     Name = "Dick",
                     Contact = "321",
                     Email = "Dick@Harry.com",

                 }
                );
        }
    }
}
