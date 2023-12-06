using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
    }

    public class UserViewModel
    {
        [Required]
        [MinLength(3)]
        public string Login { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }
    }
    public class UserOutViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Login { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
