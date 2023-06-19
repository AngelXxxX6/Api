using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{

    public class Doctor
    {

        [Key] public int Id { get; set; }
        public string FIO { get; set; }
        public string Post { get; set; }
        public int RoomNumber { get; set; }
        public TimeOnly WorkTimeStart { get; set; }
        public TimeOnly WorkTimeEnd { get; set; }

    }

    public class DoctorViewModel
    {
        [Required]
        
        public string FIO { get; set; }

        [Required]
       
        public string Post { get; set; }

        [Required]
       
        public string RoomNumber { get; set; }

        [Required]
        public DateOnly WorkTimeStart { get; set; }
        [Required]
        public DateOnly WorkTimeEnd { get; set; }
    }
}
