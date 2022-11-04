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
        T InsertAsync(T entidade);
        T UpdateAsync(T entidade);
       T SelectAsync(int id);
      IEnumerable<T> SelectAllAsync();
        bool DeleteAsync(int id);
    }
}
