using GamesAPP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public User? UserAuthenticated { get; private set; } = null;

        public bool IsUserAuthenticated
        {
            get
            {
                return this.UserAuthenticated != null;
            }
        }

        void IAuthenticationService.Login(string username, string password)
        {

        }

        void IAuthenticationService.Logout()
        {
            UserAuthenticated = null;
        }
    }
}
