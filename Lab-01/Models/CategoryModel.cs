using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab_01.Models
{
    public class CategoryModel
    {
        [Display(Name = "Mã danh mục")]
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục.")]
        public string Name { get; set; }

        // Navigation Property: Một danh mục có nhiều sản phẩm
        public ICollection<ProductModel> Products { get; set; }
    }
}