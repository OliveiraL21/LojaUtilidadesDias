﻿using Data.Context;
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

        public IEnumerable<VendaEntity> GetByDate(VendaEntity venda)
        {

            var produtos = _context.Produtos.ToList();


            var result = _dataSet.Where(v => v.Data_da_Venda == venda.Data_da_Venda)
                .Include(it => it.ItensVenda.Where(i => i.VendaId == venda.Id))
                .Include(it => it.ItensVenda.Where(i => i.ProdutoId == i.Produto.Id).ToList()); 

            return result;
            
        }
    }
}
