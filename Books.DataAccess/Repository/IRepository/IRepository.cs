using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? incluedProperties = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? incluedProperties = null);
        void Add(T item);
        void Delete(T item);
        void DeleteRange(IEnumerable<T> items);
    }
}
