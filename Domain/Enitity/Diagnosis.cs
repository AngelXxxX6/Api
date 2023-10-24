using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enitity
{
    public class Diagnosis
    {
        [Key]
        public int diagnosis_id;
        public int appointment_id;
        public string diagonsis;
    }
}
