using KalyanJewellersDemo.Models;
using KalyanJewellersDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.IServices
{
    public interface ISignUpService : IRepository<User>
    {
        new User Add(User user);
    }
}
