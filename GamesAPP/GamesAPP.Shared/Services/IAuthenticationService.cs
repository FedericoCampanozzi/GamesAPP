using GamesAPP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Shared.Services
{
    public interface IAuthenticationService
    {
        User? UserAuthenticated { get; }

        bool IsUserAuthenticated { get; }

        void Login(string username, string password);

        void Logout();
    }
}
