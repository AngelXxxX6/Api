using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity.AccountViewsModel
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(24)]
        [MinLength(3)]
        public string Login { get; set; }

        [Required()]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
