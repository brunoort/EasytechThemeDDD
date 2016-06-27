using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Infra.Data.Interface
{
    public interface IRepository<T> : IDisposable where T : class
    {
        bool Create(T entity);
        bool Update(T entity);
        T Read(int id);
        IEnumerable<T> Read();
        IEnumerable<T> Read(Expression<Func<T, bool>> predicate);
        bool Delete(T entity);
    }
}
