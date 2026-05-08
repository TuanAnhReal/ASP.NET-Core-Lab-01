using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab_01.Controllers
{
    public class ProductController : Controller
    {
        private AppDBContext _context;

        public ProductController (AppDBContext context)
        {
            _context = context;
        }

        //tìm kiếm và phân trang
        public IActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 5;

            // Lấy query ban đầu có Include Category
            var query = _context.Products.Include(p => p.Category).AsQueryable();

            // Nếu người dùng có nhập từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Name.Contains(searchString));
            }

            // Đếm tổng số sản phẩm thỏa mãn điều kiện để tính số trang
            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Lấy dữ liệu của trang hiện tại bằng Skip và Take
            var products = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Truyền dữ liệu phân trang và tìm kiếm qua View
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchString = searchString;

            return View(products);
        }

        // thống kê sp theo danh mục
        public IActionResult Statistics()
        {
            var stats = _context.Products
                .Include(p => p.Category)
                .GroupBy(p => p.Category.Name)
                .Select(g => new CategoryStatisticViewModel
                {
                    CategoryName = g.Key,
                    ProductCount = g.Count(),
                    MaxPrice = g.Max(p => p.Price),
                    MinPrice = g.Min(p => p.Price),
                    AveragePrice = g.Average(p => p.Price),
                    TotalValue = g.Sum(p => p.Price)
                }).ToList();

            return View(stats);
        }


        //trả về danh sách sản phẩm
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        //thêm mới sản phẩm vào danh sách
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Sửa sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
