using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barber.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string TypeService { get; set; }

        public decimal PriceService { get; set; }
    }
}