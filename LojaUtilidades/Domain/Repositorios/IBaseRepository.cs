using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios
{
   public interface IBaseRepository
    {
        Task<Produto> InsertAsync(Produto);
        Task<Produto> UpdateAysnc(Produto produto);
        Task<Produto> SelectAysnc(int id);
        Task<IEnumerable<Produto>> SelectAsync();
        Task<bool> Delete();
    }
}
