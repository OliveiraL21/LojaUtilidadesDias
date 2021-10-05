using Domain.Entity;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class ProdutoImplementation : GenericRepository<Produto>, IProdutoRepository
    {
        private readonly DbSet<Produto> _dataSet;
        public ProdutoImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<Produto>();
        }

        public async Task<Produto> SelectByName(string nome)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Nome == nome);
                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
