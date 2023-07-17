using System.ComponentModel.DataAnnotations;

namespace Api.Proj.Std.Domain.ViewModels
{
    public class ProfileCreateViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
    }
}
