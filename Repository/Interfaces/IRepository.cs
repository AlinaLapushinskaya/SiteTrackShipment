using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        //T Get(long id);
        //T Get(string Email);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();

        T existEntity(Expression<Func<T, bool>> predicate);
    }
}
