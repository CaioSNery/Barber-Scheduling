using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Dtos;
using Barber.Models;

namespace Barber.Interfaces
{
    public interface ISchedulingService
    {
        Task<SchedulingDTO> CreateNewScheduleingAsync(Scheduling scheduling);

        Task<bool> DeleteSchedulingByIdAsync(int id);

        Task<bool> UpdateSchedulingByIdAsync(int id, Scheduling upscheduling);

        Task<IEnumerable<SchedulingViewDTO>> GetAllSchedulingsAsync();

        Task<Scheduling> GetSchedulingByIdAsync(int id);
    }
}