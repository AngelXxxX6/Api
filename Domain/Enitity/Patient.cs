using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{
    public class Patient
    {
        [Key]
        public int patient_id { get; set; }
        public string name { get; set; }
        
        public DateOnly date_of_birth { get; set; }
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
