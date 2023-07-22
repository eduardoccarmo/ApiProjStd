using System.ComponentModel.DataAnnotations;

namespace Api.Proj.Std.Domain.ViewModels
{
    public class UserCreatedViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NickName is required.")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
    }
}
