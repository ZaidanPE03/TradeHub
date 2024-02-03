using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeHub.Server.Data;
using TradeHub.Server.IRepository;
using TradeHub.Server.Models;
using TradeHub.Server.Repository;
using TradeHub.Shared.Domain;

namespace TradeHub.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<TradeOrder> _tradeorders;
        private IGenericRepository<SellOrder> _sellorders;
        private IGenericRepository<Product> _products;
     

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<TradeOrder> TradeOrders
            => _tradeorders ??= new GenericRepository<TradeOrder>(_context);
        public IGenericRepository<SellOrder> SellOrders
            => _sellorders ??= new GenericRepository<SellOrder>(_context);
        public IGenericRepository<Product> Products
            => _products ??= new GenericRepository<Product>(_context);
     

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

       

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            //string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            //foreach (var entry in entries)
            //{
            //    ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
            //    ((BaseDomainModel)entry.Entity).UpdatedBy = user;
            //    if (entry.State == EntityState.Added)
            //    {
            //        ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
            //        ((BaseDomainModel)entry.Entity).CreatedBy = user;
            //    }
            //}

            await _context.SaveChangesAsync();
        }
    }
}