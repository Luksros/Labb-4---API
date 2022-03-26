using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labb_4___API_api.Services
{
    public interface IRepo<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetSingleAsync(int id);
        Task<T> AddAsync(T newEntity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
