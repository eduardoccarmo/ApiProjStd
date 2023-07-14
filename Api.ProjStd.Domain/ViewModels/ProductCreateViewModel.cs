using System.ComponentModel.DataAnnotations;

namespace Api.Proj.Std.Domain.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Name is Required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Category must be greater than 0.")]
        public int? Category { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double? Price { get; set; }
    }
}
