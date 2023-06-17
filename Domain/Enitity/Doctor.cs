using System.ComponentModel.DataAnnotations;

namespace Domain.Enitity
{

    public class Doctor
    {

        [Key] public int Id { get; set; }
        public string FIO { get; set; }
        public string Post { get; set; }
        public int RoomNumber { get; set; }
        public TimeOnly WorkTime { get; set; }

    }

}
