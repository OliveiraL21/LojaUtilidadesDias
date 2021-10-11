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
        Task<ProdutoEntity> Post(ProdutoEntity produto);
        Task<ProdutoEntity> Get(int id);
        Task<IEnumerable<ProdutoEntity>> GetAll();
        Task<bool> Delete(int id);
        Task<ProdutoEntity> Put(ProdutoEntity produto);
        Task<bool> DeleteByName(string nome);
        Task<ProdutoEntity> SelectByName(string nome);
    }
}
