using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Produtos
{
   public  interface IProdutoService 
    {
        Task<Produto> Post(Produto produto);
        Task<Produto> Get(int id);
        Task<IEnumerable<Produto>> GetAll();
        Task<bool> Delete(int id);
        Task<Produto> Put(Produto produto);
        Task<bool> DeleteByName(string nome);
        Task<Produto> SelectByName(string nome);
    }
}
