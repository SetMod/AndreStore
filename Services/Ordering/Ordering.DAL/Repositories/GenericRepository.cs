using Ordering.DAL.Entities;
using Ordering.DAL.Interfaces.IEntities;
using Ordering.DAL.Interfaces.IRepositories;
using Oredering.DAL.OrderigDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ordering.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly OrderingDbContext _context;
        public GenericRepository(OrderingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<T> DeleteAsync(int Id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == Id);
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity with id = {Id} does not exist");
            }
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }

        public async void SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
