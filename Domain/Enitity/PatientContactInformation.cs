using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enitity
{
    public class PatientContactInformation
    {
        [Key]
        public int contact_id;
        public int patient_id;
        public string address;
        public string phone_number;
        public string email;
    }
}
