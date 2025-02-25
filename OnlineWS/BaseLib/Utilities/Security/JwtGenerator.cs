using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseLib.Utilities.Security
{
    public class JwtGenerator
    {
        private readonly IConfiguration _configuration; // appsettings.json ı okumak için
        private TokenOptions _tokenOptions; // appsettingsdeki datanın nesne karşılığı
        private DateTime _tokenExpiration; // token ın geçerlilik süresi
        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken()
        {
            _tokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.TokenExpiration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwt = CreateJwtSecurityToken(_tokenOptions, signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = _tokenExpiration,
                Claims = new List<string> { "CLAIM1", "CLAIM2", "CLAIM3" }
            };
        }

        // asıl token'ı üretecek olan metod. Bu token signingCredentials ile imzalanacak ve _tokenOptions içindeki değerleri payload a yerleştirecek
        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, SigningCredentials signingCredentials)
        {
            var jwtSecurityToken = new JwtSecurityToken
                (
                   issuer: tokenOptions.Issuer,
                   audience: tokenOptions.Audience,
                   expires: _tokenExpiration,
                   notBefore: DateTime.Now,
                   signingCredentials: signingCredentials,
                   claims: new List<Claim> { new Claim("KEY1", "VALUE1"), new Claim("KEY2", "VALUE2"), new Claim("KEY3", "VALUE3") }
                );

            return jwtSecurityToken;

        }
    }
}
