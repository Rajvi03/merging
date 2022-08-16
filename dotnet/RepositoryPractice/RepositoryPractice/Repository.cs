using RepositoryPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPractice
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll (TEntity entity);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        private HospitalContext context { get; set; }
        public Repository(HospitalContext context)
        {
            context = new HospitalContext();
        }
        public IEnumerable<T> GetAll(T entity)
        {
            return context.Set<T>().ToList();
        }
    }
}
