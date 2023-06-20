using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enitity.AccountViewsModel
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Введите логин")]
        [MaxLength(24, ErrorMessage = "Логин должен иметь длину меньше 20 символов")]
        [MinLength(3, ErrorMessage = "Логин должен иметь длину больше 3 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Пароль должен иметь длину больше 6 символов")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]


        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage ="Укажите роль")]
        public Role UserRole { get; set; }
    }
}
