using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4___API.Services
{
    internal interface IRepo<T> 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(int id);
        Task<T> AddAsync(T newEntity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
