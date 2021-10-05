using Domain.Entity;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dataSet;
        public GenericRepository(MyContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if(result != null)
                {
                    _dataSet.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                _dataSet.Add(item);
                await _context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
            return item;
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> SelectAsync(int id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if(result == null)
                {
                    return null;
                }
                else
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
            return item;
        }
    }
}
