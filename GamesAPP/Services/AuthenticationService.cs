using GamesAPP.Data;
using GamesAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesAPP.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public static User? UserAuthenticated { get; set; } = null;

        public static bool IsUserAuthenticated
        {
            get
            {
                return UserAuthenticated != null;
            }
        }
	}
}
