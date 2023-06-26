using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity.AccountViewsModel
{
    public class RegisterViewModel
    {

        [Required()]
        [MaxLength(24)]
        [MinLength(3)]
        public string Login { get; set; }

        [Required()]
        [DataType(DataType.Password)]
        [MinLength(6)]

        public string Password { get; set; }

        [Required()]
        [Compare("Password")]
        [DataType(DataType.Password)]


        public string PasswordConfirm { get; set; }

        [Required()]
        public Role UserRole { get; set; }
    }
}
