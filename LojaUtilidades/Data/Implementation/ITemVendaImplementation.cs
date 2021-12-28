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
    public class ITemVendaImplementation : Repository<ItemVendaEntity>, ITemVendaRepository
    {
        private readonly MyContext _context;
        private readonly DbSet<ItemVendaEntity> _dataSet;
        public ITemVendaImplementation(MyContext context) : base(context)
        {
            _context = context;
            _dataSet = context.Set<ItemVendaEntity>();
        }

        
        public  IList<ItemVendaEntity> GetByName(ItemVendaEntity itemVenda)
        {
            var NomeProduto = itemVenda.Produto.Nome;
            var result = _context.ItensVendas.Where(i => i.Produto.Nome == NomeProduto).ToList();
            return result;
            
        }
    }
}
