using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.BL.Managers
{
    public class JwtTokenManager : ITokenManager<HeroEntity, string>
    {
        // Token init data. 
        private const string KEY            = "HeroesAndDragons_secretkey!123";
        public const string ISSUER          = "HeroesAndDragonsServer";
        public const string AUDIENCE        = "HeroesAndDragonsClient";
        private int tokenLifeTimeDefault    = 30;   // Minutes
        private int tokenLifeTimeLong       = 1;    // Days
        private int tokenLifeTimeShort      = 1;    // Hours

        readonly UserManager<HeroEntity> _manager;

        public JwtTokenManager(UserManager<HeroEntity> manager)
        {
            _manager = manager;
        }

        public async Task<string> GetToken(HeroEntity entity, bool remember = false)
        {
            var claims = await _manager.GetClaimsAsync(entity);

            var now = DateTime.UtcNow;

            // Generate token.
            var jwt = new JwtSecurityToken(
                    issuer: ISSUER,
                    audience: AUDIENCE,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: SetLifeTime(now, remember),
                    signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public Task<string> RefreshToken()
        {
            throw new NotImplementedException();
        }

        // Set token lifetime.
        private DateTime SetLifeTime(DateTime now, bool longPeriod)
        {
            return longPeriod ?
                now.AddDays(tokenLifeTimeLong) :
                now.AddHours(tokenLifeTimeShort);
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
