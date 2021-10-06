using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorios
{
    public interface IProdutoRepository 
    {
        Task<Produto> SelectByName(string nome);
    }
}
