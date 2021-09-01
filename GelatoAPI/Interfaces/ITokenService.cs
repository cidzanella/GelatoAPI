using GelatoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
