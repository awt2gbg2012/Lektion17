using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AWT2Demo.Domain.Entities;
using System.Data.Entity;

namespace AWT2Demo.Domain.Contexts
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}