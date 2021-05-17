using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.API.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T: IEntity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int Id);
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(int Id);
        public void SaveChangesAsync();
    }
}
