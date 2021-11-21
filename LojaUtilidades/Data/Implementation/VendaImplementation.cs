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

        public IEnumerable<VendaEntity> GetByDate(DateTime data)
        {
            try
            {
                var result =  _context.Vendas.OrderBy(v => v.Data_da_Venda == data);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
