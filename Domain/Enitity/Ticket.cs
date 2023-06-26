using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{
    public class Ticket
    {
        [Key] public int Id { get; set; }
        public string PatientFIO { get; set; }
        public string DoctorFIO { get; set; }

        public int RoomNumber { get; set; }
        public DateTime DateTimeTicket { get; set; }
    }

    public class TicketViewModel
    {
        [Required]
        [MinLength(4)]
        public string PatientFIO { get; set; }
        [Required]
        [MinLength(4)]
        public string DoctorFIO { get; set; }

        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public DateTime DateTimeTicket { get; set; }
    }

}
