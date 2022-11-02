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
        Task<Produto> Insert(Produto produto);
        Produto GetProduto(int id);
        IEnumerable<Produto> GetProdutos();
        Task<bool> Delete(int id);
        Task<Produto> Update(Produto produto);
        Task<bool> DeleteByName(string nome);
        Task<Produto> SelectByName(string nome);
    }
}
