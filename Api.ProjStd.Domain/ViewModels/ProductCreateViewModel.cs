using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Proj.Std.Domain.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Name is Required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int? Category { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "RegisterDate is required.")]
        public DateTime? RegisterDate { get; set; }

        [Required(ErrorMessage = "LastUpdateDate is required.")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
