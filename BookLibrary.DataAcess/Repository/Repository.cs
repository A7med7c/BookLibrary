using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.DataAcess.Data;
using BookLibrary.DataAcess.Repository.IRepository;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DataAcess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;
        public Repository( ApplicationDbContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
           IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault(filter);
             
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
           return query.ToList(); 

        }

        public void Remove(T entity)
        {
           dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }
    }
}
 