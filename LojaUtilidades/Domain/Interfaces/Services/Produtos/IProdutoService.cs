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
        Produto Insert(Produto produto);
        Produto GetProduto(int id);
        IEnumerable<Produto> GetProdutos();
        bool Delete(int id);
        Produto Update(Produto produto);
        bool DeleteByName(string nome);
        Produto SelectByName(string nome);
    }
}
