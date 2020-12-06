using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstelCore.Contracts;
using InstelCore.Data;

namespace InstelCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products
                .OrderBy(p => p.Header)
                .ToList();
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