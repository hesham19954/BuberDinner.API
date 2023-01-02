using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Interface.Authentication
{
    public interface IJWTGenerator
    {
        string GenerateToken(Guid guid , string FirstName , string LastName);
    }
}
