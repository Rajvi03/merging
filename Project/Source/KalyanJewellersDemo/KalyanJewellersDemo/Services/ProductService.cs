using KalyanJewellersDemo.IServices;
using KalyanJewellersDemo.Models;
using KalyanJewellersDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.Services
{
    public class ProductService : Repository<Product>, IProductService
    {
        public ProductService(KalyanJewellersContext context) : base(context)
        {
        }
    }

}