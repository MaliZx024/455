using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MaliZ.Entities;

namespace API.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
