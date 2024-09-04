using System.ComponentModel.DataAnnotations;

namespace Project_Demo.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Mô tả sản phẩm không được để trống")]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public CategoryModel Category { get; set; }
        public BrandModel Brand { get; set; }
        public string Image { get; set; }
    }
}
