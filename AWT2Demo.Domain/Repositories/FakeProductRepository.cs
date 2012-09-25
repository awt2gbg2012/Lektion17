using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AWT2Demo.Domain.Entities;

namespace AWT2Demo.Domain.Repositories
{
    public class FakeProductRepository : FakeRepository<Product>, IProductRepository
    {
        public FakeProductRepository(params Product[] products)
        {
            context = products.ToList();
        }

        public IQueryable<Product> FindProductsByCategoryID(int id)
        {
            return new List<Product>().AsQueryable();
        }
    }
}