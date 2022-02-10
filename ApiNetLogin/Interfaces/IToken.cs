﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiNetLogin.Interfaces
{
    public interface IToken
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
