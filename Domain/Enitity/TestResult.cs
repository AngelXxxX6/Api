using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enitity
{
   public class TestResult
    {
        [Key]
        public int test_result_id;
        public int appointment_id;
        public string test_result;
    }
}
