using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{
    public class User
    {

        [Key] public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class UserViewModel
    {
        [Required]
        [MinLength(3)]
        public string Login { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}

