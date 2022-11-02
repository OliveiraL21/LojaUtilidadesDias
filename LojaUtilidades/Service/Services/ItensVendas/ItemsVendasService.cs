using Data.Context;
using Data.Implementation;
using Domain.Entidades;
using Domain.Interfaces.Services;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.ItensVendas
{
    public class ItemsVendasService : IITemVendaService
    {
        private readonly ITemVendaRepository _repository;
        private readonly MyContext _context;
        public ItemsVendasService(ITemVendaRepository repository, MyContext context)
        {
            _repository = repository;
            _context = context;
        }
        public ItemsVendasService()
        {
            _repository = new ITemVendaImplementation(new MyContext(new DbContextOptions<MyContext>()));
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);
                return false;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ItemVenda> GetItens()
        {
            var result =  _repository.SelectAllAsync();

            if (result == null)
                return null;

            return result;

        }

        public  ItemVenda GetById(int id)
        {
            var result =  _repository.SelectAsync(id);
            if (result == null)
                return null;

            return result;
        }
   
        public async Task<ItemVenda> Insert(ItemVenda item)
        {
            var result = await _repository.InsertAsync(item);
            if (result == null)
                return null;

            return result;
        }

        public async Task<ItemVenda> Update(ItemVenda item)
        {
            var result = await _repository.UpdateAsync(item);
            if (result == null)
                return null;

            return result;
        }
    }
}
