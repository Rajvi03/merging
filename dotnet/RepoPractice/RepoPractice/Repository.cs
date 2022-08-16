using RepoPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoPractice
{
        public interface IRepository<TEntity> where TEntity : class
        {
            List<TEntity> GetAll();
        }
        public class Repository<T> : IRepository<T> where T : class
        {
            private HospitalContext context { get; set; }
            public Repository(HospitalContext DbContext)
            {
                context = DbContext;
            }
            public List<T> GetAll()
            {
                return context.Set<T>().ToList();
            }
        }

    
}
