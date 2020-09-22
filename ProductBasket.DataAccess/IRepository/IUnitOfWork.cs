using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBasket.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ISP_Call SP_Call { get; }
        public void Dispose();
        public void Save();
    }
}
