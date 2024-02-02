using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                     Name = "Iphone 11",
                     Description = "Liquid Retina HD display.",
                     Type = "Mobile Phone",
                     Quantity = 25,
                     Price = 1600,

                 },
                 new Product
                 {
                     Id = 2,
                     Name = "Asus VivoBook",
                     Type = "Laptop",
                     Quantity = 15,
                     Price = 2300,
                 },
                new Product
                {
                    Id = 3,
                    Name = "Asus Ultra Thin",
                    Type = "Laptop",
                    Quantity = 15,
                    Price = 1000,
                }
                );
        }
    }
}
