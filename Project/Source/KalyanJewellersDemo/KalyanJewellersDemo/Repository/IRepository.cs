using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
      
        List<TEntity> GetAll();
        TEntity GetById(int id);

        TEntity Add(TEntity entity);
        TEntity Put(TEntity entity, TEntity entity1);

        TEntity Delete(TEntity entity);
    }
}
