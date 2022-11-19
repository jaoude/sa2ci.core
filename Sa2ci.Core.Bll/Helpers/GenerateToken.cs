using Microsoft.IdentityModel.Tokens;
using Sa2ci.Core.Dal.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Helpers
{

    public class GenerateToken
    {
        public string Token = string.Empty;
        //public User User = null;

        public  GenerateToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("149871121337AFBC5576B0DAFE9DA6E99A6D667A3BA770AB32857E49F18BFC2C");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            foreach (var x in user.UserRoles)
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, x.Role.Name));

            var token = tokenHandler.CreateToken(tokenDescriptor);
            Token = tokenHandler.WriteToken(token);
        }
    }
}
