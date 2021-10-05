using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<Produto> Post(Produto produto);
        Task<Produto> GetById(int id);
        Task<Produto> GetByName(string name);
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> Put(Produto produto);
        Task<bool> Delete(int id);


    }
}
