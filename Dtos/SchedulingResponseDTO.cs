using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barber.Dtos
{
    public class SchedulingResponseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int ServiceId { get; set; }
        public ServiceDTO Service { get; set; }
        public DateTime DateScheduling { get; set; }
    }
}