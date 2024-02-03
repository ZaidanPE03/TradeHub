using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using TradeHub.Shared.Domain;

namespace TradeHub.Server.Configuration.Entities
{
    public class ProductSeedConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                 new Product
                 {
                     Id = 1,
                     Name = "Toaster",
                     Description = "Mini Electric Toaster",
                     Type = "Electronics",
                     Quantity = 1,
                     Price = 30.50f,

                    
                 },
                 new Product
                 {
                     Id = 2,
                     Name = "Carbon Fiber Road Bicycle",
                     Description = "Fast and lightweight road bike",
                     Type = "Bicycles",
                     Quantity = 1,
                     Price = 2000,

                  

                 }
                );
        }
    }
}
