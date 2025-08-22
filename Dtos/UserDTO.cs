using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barber.Dtos
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Telephone { get; set; }
    }
}