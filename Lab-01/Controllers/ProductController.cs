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
        public static List<ProductModel> dsSanPham = new List<ProductModel> {
           new ProductModel{ ID = 1, Name = "Nho", Price = 20000 },
           new ProductModel{ ID = 2, Name = "Táo", Price = 50000 },
           new ProductModel{ ID = 3, Name = "Chuối", Price = 90000 }
        };
        public IActionResult Index()
        {
            return View(dsSanPham);
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
                if(dsSanPham.Any(p => p.ID == product.ID))
                {
                    ModelState.AddModelError("Id", "Mã sản phẩm này đã tồn tại!");
                    return View(product);
                }
                if (product.Name == null)
                {
                    ModelState.AddModelError("Name", "Tên sản phẩm không được để trống!");
                    return View(product);
                }

                dsSanPham.Add(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
