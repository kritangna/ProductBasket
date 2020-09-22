using ProductBasket.DataAccess.Data;
using ProductBasket.DataAccess.IRepository;
using ProductBasket.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBasket.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IProductRepository Product { get; private set; }

        public ISP_Call SP_Call { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Product = new ProductRepository(_db);
            SP_Call = new SP_Call(_db);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
