using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Dtos;
using Barber.Models;

namespace Barber.Interfaces
{
    public interface IServicesService
    {
        Task<object> CreateTypeServiceAsync(Service service);

        Task<bool> DeleteServiceAsync(int id);

        Task<bool> UpdateServiceByIdAsync(int id, Service servup);

        Task<IEnumerable<ServiceViewDTO>> GetServices();
    }
}