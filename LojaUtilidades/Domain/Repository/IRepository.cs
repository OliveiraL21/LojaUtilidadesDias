using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository <T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entidade);
        Task<T> UpdateAsync(T entidade);
        Task<T> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAllAsynck();
        Task<bool> DeleteAsync(int id);
    }
}
