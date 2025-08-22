using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Dtos;
using Barber.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Interfaces
{
    public interface ISchedulingService
    {
        Task<SchedulingResponseDTO> CreateNewScheduleingAsync(SchedulingDTO dto);

        Task<bool> DeleteSchedulingByIdAsync(int id);

        Task<bool> UpdateSchedulingByIdAsync(int id, Scheduling upscheduling);

        Task<IEnumerable<SchedulingResponseDTO>> GetAllSchedulingsAsync();

        Task<SchedulingResponseDTO> GetSchedulingByIdAsync(int id);

        Task<List<Scheduling>> GetSchedulingByDay(DateTime date);
    }
}