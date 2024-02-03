using TradeHub.Server.Data;
using TradeHub.Server.IRepository;
using TradeHub.Server.Models;
using TradeHub.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeHub.Server.Repository;
using CarRentalManagement.Server.Repository;


namespace TradeHub.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Product> _products;
        private IGenericRepository<SellOrder> _sellorders;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<TradeOrder> _tradeorders;
        private IGenericRepository<Customer> _customers;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Product> Products
            => _products ??= new GenericRepository<Product>(_context);

        public IGenericRepository<SellOrder> SellOrders
            => _sellorders ??= new GenericRepository<SellOrder>(_context);

        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);

        public IGenericRepository<TradeOrder> TradeOrders
            => _tradeorders ??= new GenericRepository<TradeOrder>(_context);

        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);

        public async Task Save(HttpContext httpContext)
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
