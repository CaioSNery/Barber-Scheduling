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
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<object> CreateUserAsync(User user)
        {
            if (user != null)
                _context.Add(user);
            await _context.SaveChangesAsync();

            return user;

        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return false;

            _context.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return null;

            return user;
        }

        public async Task<IEnumerable<UserViewDTO>> GetAllUsersAsync()
        {
            var result = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserViewDTO>>(result);
        }

        public async Task<bool> UpdateUserByIdAsync(int id, User userup)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.Name = userup.Name;
            user.Cpf = userup.Cpf;
            user.Telephone = userup.Telephone;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}