using KalyanJewellersDemo.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.Authentication
{
    public interface IAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
    public class AuthenticationManager : IAuthenticationManager
    {
        private KalyanJewellersContext context { get; set; }

        private readonly string tokenKey;

        public AuthenticationManager(string tokenKey, KalyanJewellersContext DbContext)
        {
            this.tokenKey = tokenKey;
            context = DbContext;
        }
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        public string Authenticate(string username, string password)
        {
            var pas = context.Users.Where(u => u.Email == username || u.MobileNo == username).FirstOrDefault();
            string x = pas.Password;
            string pass = DecodeFrom64(x);
            var users = context.Users.Where(u => u.Email == username || u.MobileNo == username  && u.Password == password).FirstOrDefault();
            if (users == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.FirstName),
                    new Claim(ClaimTypes.Role, users.UserRole)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
