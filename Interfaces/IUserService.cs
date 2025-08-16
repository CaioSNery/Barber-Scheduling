using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Dtos;
using Barber.Models;

namespace Barber.Interfaces
{
    public interface IUserService
    {
        Task<object> CreateUserAsync(User user);

        Task<bool> DeleteUserByIdAsync(int id);

        Task<bool> UpdateUserByIdAsync(int id, User userup);

        Task<IEnumerable<UserViewDTO>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int id);
    }
}