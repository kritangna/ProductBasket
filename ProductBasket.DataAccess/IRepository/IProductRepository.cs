using ProductBasket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBasket.DataAccess.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        public void Update(Product product);
    }
}
