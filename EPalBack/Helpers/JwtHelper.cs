using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EPalBack.Helpers
{
    public class JwtHelper
    {

        public static string Issuer => "BuildSchool";
        public static SymmetricSecurityKey SecurityKey => new(Encoding.UTF8.GetBytes("njkmdmdkslfkdsfksmdkmfkdsmflmlfmomodmfomffs"));


        //自製jwt token
        public string GenerateToken(string username)
        {

            //發行者
            var issuer = "BuildSchool";
            //匿名
            var signKey = "njkmdmdkslfkdsfksmdkmfkdsmflmlfmomodmfomffs";

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, username));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var userClaimIdentity = new ClaimsIdentity(claims);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
            var signCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptior = new SecurityTokenDescriptor()
            {
                //發行者
                Issuer = issuer,
                //發行時間
                IssuedAt = DateTime.UtcNow,
                //訂閱者
                Subject = userClaimIdentity,
                //有效時間
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = signCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptior);
            var serializeToken = tokenHandler.WriteToken(securityToken);
            return serializeToken;

        }


    }
}
