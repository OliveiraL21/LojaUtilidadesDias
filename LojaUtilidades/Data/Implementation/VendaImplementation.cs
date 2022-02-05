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
    public class VendaImplementation : Repository<VendaEntity>, IVendaRepository
    {
        private readonly DbSet<VendaEntity> _dataSet;
        private readonly MyContext _context;
        public VendaImplementation(MyContext context) : base(context)
        {
            _context = context;
            _dataSet = context.Set<VendaEntity>();
        }

        public IEnumerable<VendaEntity> GetVendas()
        {
            var result = _dataSet.AsNoTracking().Include(v => v.ItensVenda)
                .ThenInclude(it => it.Produto).ToList();

            return result;

        }
        public IEnumerable<VendaEntity> GetByDate(VendaEntity venda)
        {
            var result = _dataSet.Where(v => v.Data_da_Venda == venda.Data_da_Venda).Include(v => v.ItensVenda).ThenInclude(it => it.Produto).ToList();

            return result;
        }

        public IEnumerable<VendaEntity> GetByNumber(VendaEntity venda)
        {
            var result = _dataSet.AsNoTracking().Include(v => v.ItensVenda)
                                 .ThenInclude(it => it.Produto).Where(v => v.NumeroVenda == venda.NumeroVenda).ToList();

            return result;
        }
        //public IEnumerable<VendaEntity>GetByProductName(string produto)
        //{
        //    var result = _dataSet.AsNoTracking().Include(v => v.ItensVenda)
        //                         .ThenInclude(it => it.Produto).ToList();

        //    List<ItemVendaEntity> lstItemVenda = new List<ItemVendaEntity>();

        //    foreach(var item in result)
        //    {
        //        foreach(var itemVenda in item.ItensVenda)
        //        {
        //            if(itemVenda.Produto.Nome == produto)
        //            {
        //                lstItemVenda.Add( new ItemVendaEntity() 
        //                {
        //                    Id = itemVenda.Id,
        //                    Produto = itemVenda.Produto,
        //                    ProdutoId = itemVenda.ProdutoId,
        //                    Venda = itemVenda.Venda,
        //                    VendaId = itemVenda.VendaId,
        //                    Quantidade = itemVenda.Quantidade
        //                });
        //                item.ItensVenda = (List<ItemVendaEntity>)lstItemVenda.Where(p => p.Produto.Nome == produto);
        //            }
        //        }
        //    }

            
        //    return result;
        //}
        public List<VendaEntity> GetAllNumberVenda()
        {
            try
            {
                var result = _dataSet.ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
