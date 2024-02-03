using TradeHub.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TradeHub.Server.IRepository;


namespace TradeHub.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<TradeOrder> TradeOrders { get; }
        IGenericRepository<SellOrder> SellOrders { get; }
        IGenericRepository<Product> Products { get; }
        
    }
}