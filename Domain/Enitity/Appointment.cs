using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enitity
{
   public class Appointment
    {

        [Key]
        public int appointment_id { get; set; }
        public int patient_id { get; set; }

        public int doctor_id { get; set; }

        public int room_id { get; set; }

        public DateOnly appointment_date { get; set; }

        public TimeOnly appointment_time { get; set; }

        public string problem_description { get; set; }

        public AppointmentStatus status { get; set; }

    }
}
