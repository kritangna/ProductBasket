using ProductBasket.DataAccess.Data;
using ProductBasket.DataAccess.IRepository;
using ProductBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductBasket.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
       // private readonly Repository<Product> _repo;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }
       
        public void Update(Product product)
        {
            var objectFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
            if (objectFromDb != null)
            {
                objectFromDb.ProdName = product.ProdName;
                objectFromDb.ProdImageName = product.ProdImageName;
                objectFromDb.ProdPrice = product.ProdPrice;
                _db.SaveChanges();
            }
        }
    }
}
