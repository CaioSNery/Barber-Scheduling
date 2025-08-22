using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Barber.Data;
using Barber.Dtos;
using Barber.Interfaces;
using Barber.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<SchedulingResponseDTO> CreateNewScheduleingAsync(SchedulingDTO dto)
        {
            bool existeagendamento = await _context.Schedulings.AnyAsync(s =>
            s.DateScheduling == dto.DateScheduling &&
             s.UserId == dto.UserId);

            if (existeagendamento)
                throw new Exception("Ja Existe agendamento para essa horario");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == dto.ServiceId);
            if (service == null)
                throw new Exception("Serviço não encontrado");

            var scheduling = _mapper.Map<Scheduling>(dto);

            _context.Schedulings.Add(scheduling);

            await _context.SaveChangesAsync();

            return _mapper.Map<SchedulingResponseDTO>(scheduling);
        }

        public async Task<bool> DeleteSchedulingByIdAsync(int id)
        {
            var scheduling = await _context.Schedulings.FindAsync(id);
            if (scheduling == null) return false;

            _context.Remove(scheduling);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SchedulingResponseDTO>> GetAllSchedulingsAsync()
        {
            var schedulings = await _context.Schedulings.ToListAsync();
            if (schedulings == null) return null;

            return _mapper.Map<IEnumerable<SchedulingResponseDTO>>(schedulings);
        }

        public async Task<List<Scheduling>> GetSchedulingByDay(DateTime dateScheduling)
        {
            return await _context.Schedulings
            .Where(p => p.DateScheduling.Date == dateScheduling.Date)
            .ToListAsync();
        }

        public async Task<SchedulingResponseDTO> GetSchedulingByIdAsync(int id)
        {
            var scheduling = await _context.Schedulings.FindAsync(id);
            if (scheduling == null) return null;

            return _mapper.Map<SchedulingResponseDTO>(scheduling);
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