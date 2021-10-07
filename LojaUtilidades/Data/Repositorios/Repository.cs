using Data.Context;
using Domain.Entidades;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dataSet;

        public Repository(MyContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id == id);
                if(result != null)
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> InsertAsync(T entidade)
        {
            try
            {
                _dataSet.Add(entidade);
                await _context.SaveChangesAsync();
                return entidade;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> SelectAllAsynck()
        {
            try
            {
                var result = await _dataSet.ToListAsync();
                return result;
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
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id == id);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entidade)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(entidade.Id));
                if (result == null)
                {
                    return null;
                }
                _context.Entry(result).CurrentValues.SetValues(entidade);
                await _context.SaveChangesAsync();
                return entidade;
            }
            catch
            {
                throw;
            }
        }
    }
}
