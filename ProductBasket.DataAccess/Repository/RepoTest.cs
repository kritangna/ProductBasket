using ProductBasket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBasket.DataAccess.Repository
{
    public class RepoTest
    {
        private readonly Repository<Product> _repoProd;
        public RepoTest(Repository<Product> repoProd)
        {
            _repoProd = repoProd;
        }
        public string CallGetStr(Repository<Product> abc)
        {
            return abc.GetStr(1);
        }
        public Product CallGet(Repository<Product> abc, int id)
        {
            return abc.Get(id);
        }
        public void CallAdd(Repository<Product> abc,Product product)
        {
            abc.Add(product);
        }
    }
}
