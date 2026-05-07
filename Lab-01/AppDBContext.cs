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
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data cho Category
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Điện thoại" },
                new CategoryModel { Id = 2, Name = "Laptop" }
            );

            // Seed Data cho Product (Có liên kết CategoryId)
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { ID = 1, Name = "iPhone", Price = 25000000, CategoryId = 1 },
                new ProductModel { ID = 2, Name = "Dell", Price = 18000000, CategoryId = 2 },
                new ProductModel { ID = 3, Name = "Lenovo", Price = 15000000, CategoryId = 2 },
                new ProductModel { ID = 4, Name = "Mac Book", Price = 30000000, CategoryId = 2 }
            );
        }
    }



}
