using Project_Demo.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0.01,double.MaxValue)]
        [Column(TypeName ="decimal(8,2)")]
        public decimal Price { get; set; }
        [Required,Range(1,int.MaxValue,ErrorMessage ="Chọn một thương hiệu")]
        public int BrandID { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Chọn một danh mục")]
        public int CategoryID { get; set; }
        public CategoryModel Category { get; set; }
        public BrandModel Brand { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile? ImageUpload { get; set; }
    }
}
