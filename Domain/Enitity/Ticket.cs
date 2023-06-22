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
        public string PatientFIO { get; set; }
        [Required]
        public string DoctorFIO { get; set; }

        [Required]
        public int RoomNumber { get; set;}
        [Required]
        public DateTime DateTimeTicket { get; set; }
    }

}
