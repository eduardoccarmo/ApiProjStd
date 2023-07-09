using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage ="Field { Name } is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field { Brand } is required.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Field { Category } is required.")]
        public int Category { get; set; }

        [Required(ErrorMessage = "Field { Price } is required.")]
        public double Price { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
