using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public DateOnly DateBirthday { get; set; }
    }

    public class PatientViewModel
    {
        [Required]
        [MinLength(8)]
        public string FIO { get; set; }

        [Required]
        [MinLength(8)]
        public string Adress { get; set; }

        [Required]
        [MinLength(6)]
        public string Phone { get; set; }

        [Required]
        public DateOnly DateBirthday { get; set; }
    }
}
