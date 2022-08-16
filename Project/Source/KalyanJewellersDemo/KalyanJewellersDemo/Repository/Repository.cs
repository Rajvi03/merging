using KalyanJewellersDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public KalyanJewellersContext context { get; set; }

        public Repository(KalyanJewellersContext DbContext)
        {
            context = DbContext;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Put(T entity, T entity1)
        {
            context.Entry(entity).CurrentValues.SetValues(entity1);
            context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
