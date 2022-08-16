using KalyanJewellersDemo.IServices;
using KalyanJewellersDemo.Models;
using KalyanJewellersDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.Services
{
   
    public class SignUpService : Repository<User>, ISignUpService
    {
        private KalyanJewellersContext dbContext { get; set; }
        public SignUpService(KalyanJewellersContext context) : base(context)
        {
            dbContext = context;
        }
        public new User Add(User user)
        {
            try
            {
                User checkEmail = dbContext.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                if(checkEmail != null)
                {
                    return null;
                }
                else
                {
                    //PassEncoding(user);
                    base.Add(user);
                    return user;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        private static void PassEncoding(User user)
        {
            byte[] encData_byte = new byte[user.Password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(user.Password);
            string encodedData = Convert.ToBase64String(encData_byte);
            Console.WriteLine(encodedData);
            user.Password = encodedData;
        }
    }
}
