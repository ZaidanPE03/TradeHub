﻿using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TradeHub.Server.Configuration.Entities;
using TradeHub.Server.Configurations.Entities;
using TradeHub.Server.Models;
using TradeHub.Shared.Domain;

namespace TradeHub.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TradeOrder> TradeOrders { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new StaffSeedConfiguration());
            builder.ApplyConfiguration(new CustomerSeedConfiguration());
            builder.ApplyConfiguration(new ProductSeedConfiguration());

            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
        }
       

    }
}