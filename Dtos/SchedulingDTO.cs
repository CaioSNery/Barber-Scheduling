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
        public User User { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}