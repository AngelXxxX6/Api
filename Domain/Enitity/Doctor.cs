using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Post { get; set; }
        public int RoomNumber { get; set; }
        public TimeOnly WorkTimeStart { get; set; }
        public TimeOnly WorkTimeEnd { get; set; }
    }

    public class DoctorViewModel
    {
        [Required]
        [MinLength(4)]
        public string FIO { get; set; }

        [Required]
        public string Post { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public TimeOnly WorkTimeStart { get; set; }

        [Required]
        public TimeOnly WorkTimeEnd { get; set; }
    }
}
