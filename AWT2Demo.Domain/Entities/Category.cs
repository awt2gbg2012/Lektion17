using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AWT2Demo.Domain.Entities.Abstract;

namespace AWT2Demo.Domain.Entities
{
    public class Category : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}