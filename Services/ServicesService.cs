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
    public class ServicesService : IServicesService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ServicesService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<object> CreateTypeServiceAsync(Service service)
        {
            if (service != null)
                _context.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            var user = await _context.Services.FindAsync(id);
            if (user == null) return false;
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceViewDTO>> GetServices()
        {
            var services = await _context.Services.ToListAsync();
            if (services == null) return null;

            return _mapper.Map<IEnumerable<ServiceViewDTO>>(services);

        }

        public Task<bool> UpdateServiceByIdAsync(int id, User userup)
        {
            throw new NotImplementedException();
        }
    }
}