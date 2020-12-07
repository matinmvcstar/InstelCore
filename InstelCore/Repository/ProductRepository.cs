using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstelCore.Contracts;
using InstelCore.Data;
using Microsoft.EntityFrameworkCore;

namespace InstelCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddEntity(object model)
        {
            _db.Add(model);
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products
                .OrderBy(p => p.Header)
                .ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _db.orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            //return _db.orders.Find(id);
            return _db.orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductByCategory(int category)
        {
            return _db.Products
                .Where(p => p.CategoryId == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return _db.SaveChanges() > 0;
        }
    }
}