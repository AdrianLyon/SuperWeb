using Microsoft.EntityFrameworkCore;
using BackEnd.SuperMarket.Models;

namespace BackEnd.SuperMarket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories{get;set;}
        public DbSet<Product> Products{get;set;}
        public DbSet<ProductSuper> ProductSupers{get; set;}
        public DbSet<ProductTest>ProductTests{get; set;}
    }
}