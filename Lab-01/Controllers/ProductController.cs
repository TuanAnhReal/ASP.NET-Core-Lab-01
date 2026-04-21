using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_01.Models;

namespace Lab_01.Controllers
{
    public class ProductController : Controller
    {
        private AppDBContext _context;

        public ProductController (AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var product = _context.Products.ToList();
            return View(product);
        }


        //trả về danh sách sản phẩm
        public IActionResult Create()
        {
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
                
            }
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id); 
                _context.Products.Remove(product);
                _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
