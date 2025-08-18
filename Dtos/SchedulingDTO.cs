using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Models;

namespace Barber.Dtos
{
    public class SchedulingDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateScheduling { get; set; }

    }
}