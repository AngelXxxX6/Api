using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enitity
{
    public class Room
    {
        [Key]
        public int room_id;
        public string room_number;
        public string equipment;
    }
}
