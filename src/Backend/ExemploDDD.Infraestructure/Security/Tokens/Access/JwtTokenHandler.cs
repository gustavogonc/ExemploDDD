﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExemploDDD.Infraestructure.Security.Tokens.Access;
public abstract class JwtTokenHandler
{
    protected static SymmetricSecurityKey SecurityKey(string signinKey)
    {
        var bytes = Encoding.UTF8.GetBytes(signinKey);

        return new SymmetricSecurityKey(bytes);
    }
}

