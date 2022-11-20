using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace AllDailyDuties_Gateway
{
    public class TokenService
    {
        public static TokenValidationParameters CreateTokenValidationParameters()
        {
            var result = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,

                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                {
                    var jwt = new JwtSecurityToken(token);
                    return jwt;
                },
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            };
            result.RequireSignedTokens = true;
            return result;
        }
    }
}
