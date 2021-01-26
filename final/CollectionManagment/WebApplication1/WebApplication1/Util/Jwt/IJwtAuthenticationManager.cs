using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Jwt
{
   public interface IJwtAuthenticationManager
    {
        string Authenticate(string login, string password , string role);
    }
}
