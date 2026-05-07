using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_01.Models
{
    public class ProductModel
    {
        [Display(Name = "Mã sản phẩm")]
        public int ID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        public string Name { get; set; }

        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0.")]
        public double Price { get; set; }

        // Khóa ngoại
        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        public int CategoryId { get; set; }

        // Navigation Property
        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }
    }
}