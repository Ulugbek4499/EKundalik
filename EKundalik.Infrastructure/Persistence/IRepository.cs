using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKundalik.Infrastructure.Persistence
{
    public interface IRepository<T> where T: class
    {
        public Task AddAsync(T obj);
        public Task AddRangeAsync(List<T> obj);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
