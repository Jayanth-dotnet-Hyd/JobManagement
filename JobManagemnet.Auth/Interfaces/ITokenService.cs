using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagemnet.Auth.Interfaces
{
    internal interface ITokenService
    {
        string GenerateToken(long userId,string email, string role);
    }
}
