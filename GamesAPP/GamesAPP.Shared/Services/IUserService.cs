using GamesAPP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<List<string>> GetAllRoles();
        Task<User> AddUser(User user);
        Task<User> EditUser(int id, User user);
    }
}
