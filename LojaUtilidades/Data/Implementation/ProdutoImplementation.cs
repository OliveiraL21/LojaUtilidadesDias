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

        public  bool DeleteByName(string nome)
        {
            var result =  _dataSet.SingleOrDefault(p => p.Nome == nome);
            _dataSet.Remove(result);
             _context.SaveChangesAsync();
            return true;
        }



        public Produto SelectByName(string nome)
        {
            var result =  _dataSet.SingleOrDefault(p => p.Nome == nome);
            return result;
        }

        
    }
}

