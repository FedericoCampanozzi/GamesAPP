using GamesAPP.Data;
using GamesAPP.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        async Task<User> IUserService.EditUser(int id, User user)
        {
            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser != null)
            {
                dbUser.Role = user.Role;
                await _context.SaveChangesAsync();
                return dbUser;
            }
            throw new Exception("User not found");
        }

        public async Task<List<string>> GetAllRoles()
        {
            var roles = await _context.Users
                .Select(u => u.Role)
                .Distinct()
                .ToListAsync();

            return roles;
        }

        async Task<List<User>> IUserService.GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

		bool IUserService.Login(string username, string password)
		{
			AuthenticationService.UserAuthenticated = _context.Users.Where(
					u => u.UserName == username && u.Password == password
				).FirstOrDefault<User>();
			Console.WriteLine($"\nTry to Login {username} {AuthenticationService.UserAuthenticated?.ToString()}\n");
			return AuthenticationService.IsUserAuthenticated;
		}

		void IUserService.Logout()
		{
			AuthenticationService.UserAuthenticated = null;
		}

		public async Task<User> GetUserById(int id)
		{
            return await _context.Users.FindAsync(id);
		}
	}
}
