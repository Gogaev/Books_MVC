using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Books.DataAccess.Data;
using Books.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Books.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.Products.Include(x => x.Category);
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public void DeleteRange(IEnumerable<T> items)
        {
            dbSet.RemoveRange(items);
        }

        public IEnumerable<T> GetAll(string? incluedProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(!string.IsNullOrEmpty(incluedProperties))
            {
                foreach(var item in incluedProperties
                    .Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? incluedProperties = null)
        {
            IQueryable<T> query = dbSet.Where(filter);
            if (!string.IsNullOrEmpty(incluedProperties))
            {
                foreach (var item in incluedProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }
    }
}
