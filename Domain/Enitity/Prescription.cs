using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enitity
{
   public class Prescription
    {
        [Key]
        public int prescription_id;
        public int appointment_id;
        public string prescription;
    }
}
