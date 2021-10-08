using Data.Context;
using Data.Repositorios;
using Domain.Entidades;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class ProdutoImplementation : Repository<ProdutoEntity>, IProdutoRepository
    {
        private readonly DbSet<ProdutoEntity> _dataSet;
        public ProdutoImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<ProdutoEntity>();
        }

        public async Task<ProdutoEntity> SelectByName(string nome)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Nome == nome);
               
               
                return result;
                
            }
            catch
            {
                throw;
            }
        }
    }
}
