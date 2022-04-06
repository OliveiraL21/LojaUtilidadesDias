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
    public class ProdutoImplementation : Repository<Produto>, IProdutoRepository
    {
        private readonly DbSet<Produto> _dataSet;
        private readonly MyContext _context;
        public ProdutoImplementation(MyContext context) : base(context)
        {
            _context = context;
            _dataSet = context.Set<Produto>();
        }

        public async Task<bool> DeleteByName(string nome)
        {

            var result = await _dataSet.SingleOrDefaultAsync(p => p.Nome == nome);
            _dataSet.Remove(result);
            await _context.SaveChangesAsync();
            return true;

        }



        public async Task<Produto> SelectByName(string nome)
        {

            var result = await _dataSet.SingleOrDefaultAsync(p => p.Nome == nome);


            return result;

        }

        
    }
}

