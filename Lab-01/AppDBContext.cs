using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab_01.Models;

namespace Lab_01
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { ID = 1, Name = "Nho", Price = 20000 },
            new ProductModel { ID = 2, Name = "Táo", Price = 50000 },
            new ProductModel { ID = 3, Name = "Chuối", Price = 90000 }
                );
        }
    }



}
