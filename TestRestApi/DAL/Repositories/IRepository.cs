using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        T GetByID(int ID);
        IEnumerable<T> GetAll();
        T Update(int ID, T entity);
        T Insert(T entity);
        void Delete(int ID);
    }
}
