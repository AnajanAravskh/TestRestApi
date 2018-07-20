using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetByID(int ID);
        IQueryable<T> GetAll();
        T Update(int ID, T entity);
        T Insert(T entity);
        Task DeleteAsync(int ID);
    }
}
