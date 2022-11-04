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
        public bool DeleteAsync(int id)
        {
            var result =  _dataSet.SingleOrDefault(p => p.Id == id);
            if (result != null)
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

        public T InsertAsync(T entity)
        {
            _dataSet.Add(entity);
             _context.SaveChanges();
            return entity;
        }

        public  IEnumerable<T> SelectAllAsync()
        {
            var result =  _dataSet.ToList();
            return result;
        }

        public T SelectAsync(int id)
        {
            var result =  _dataSet.SingleOrDefault(p => p.Id == id);
            return result;
        }

        public T UpdateAsync(T entidade)
        {
            var result =  _dataSet.SingleOrDefault(p => p.Id.Equals(entidade.Id));
            if (result == null)
            {
                return null;
            }
            _context.Entry(result).CurrentValues.SetValues(entidade);
             _context.SaveChanges();
            return entidade;
        }
    }
}
