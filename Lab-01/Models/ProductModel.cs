using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab_01.Models
{
    public class ProductModel
    {
        [Display(Name = "Mã sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập mã sản phẩm.")]
        public int ID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        public string Name { get; set; }

        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm không được là số âm.")]
        public double Price { get; set; }
    }
}
