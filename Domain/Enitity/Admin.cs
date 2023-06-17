using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{
    public class Admin
    {
        [Key] public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public AdminRole Role { get; set; }

    }
}
