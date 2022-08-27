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
    public class ITemVendaImplementation : Repository<ItemVenda>, ITemVendaRepository
    {
        private readonly MyContext _context;
        private readonly DbSet<ItemVenda> _dataSet;
        public ITemVendaImplementation(MyContext context) : base(context)
        {
            _context = context;
            _dataSet = context.Set<ItemVenda>();
        }
        public  IList<ItemVenda> GetByName(ItemVenda itemVenda)
        {
            var result = _context.ItensVendas.Where(i => i.Produto.Nome == itemVenda.Produto.Nome).ToList();
            return result;
        }
    }
}
