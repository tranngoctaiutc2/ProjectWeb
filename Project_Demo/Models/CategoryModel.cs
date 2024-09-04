using System.ComponentModel.DataAnnotations;

namespace Project_Demo.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(4,ErrorMessage ="Tên danh mục không được để trống")]
        public string Name { get; set; }
        [Required, MinLength(4, ErrorMessage = "Mô tả danh mục không được để trống")]
        public string Description { get; set; }
        [Required]
        public string Slug { get; set; }
        public int Status { get; set; }
    }
}
