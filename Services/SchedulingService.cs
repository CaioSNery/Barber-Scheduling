using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Barber.Data;
using Barber.Dtos;
using Barber.Interfaces;
using Barber.Models;
using Microsoft.EntityFrameworkCore;

namespace Barber.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SchedulingService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SchedulingDTO> CreateNewScheduleingAsync(Scheduling scheduling)
        {
            bool existeagendamento = await _context.Schedulings.AnyAsync(s =>
            s.DateScheduling == scheduling.DateScheduling &&
             s.UserId == scheduling.UserId);

            if (existeagendamento)
                throw new Exception("Ja Existe agendamento para essa horario");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == scheduling.UserId);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == scheduling.ServiceId);
            if (service == null)
                throw new Exception("Serviço não encontrado");

            _context.Schedulings.Add(scheduling);

            await _context.SaveChangesAsync();

            return _mapper.Map<SchedulingDTO>(scheduling);
        }

        public async Task<bool> DeleteSchedulingByIdAsync(int id)
        {
            var scheduling = await _context.Schedulings.FindAsync(id);
            if (scheduling == null) return false;

            _context.Remove(scheduling);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SchedulingViewDTO>> GetAllSchedulingsAsync()
        {
            var schedulings = await _context.Schedulings.ToListAsync();
            if (schedulings == null) return null;

            return _mapper.Map<IEnumerable<SchedulingViewDTO>>(schedulings);
        }

        public async Task<Scheduling> GetSchedulingByIdAsync(int id)
        {
            var scheduling = await _context.Schedulings.FindAsync(id);
            if (scheduling == null) return null;

            return _mapper.Map<Scheduling>(scheduling);
        }

        public async Task<bool> UpdateSchedulingByIdAsync(int id, Scheduling upscheduling)
        {
            var scheduling = await _context.Schedulings.FindAsync(id);
            if (scheduling == null) return false;

            scheduling.ServiceId = upscheduling.ServiceId;
            scheduling.UserId = upscheduling.UserId;
            scheduling.DateScheduling = upscheduling.DateScheduling;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}