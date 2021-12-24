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
        public ItemsVendasService(ITemVendaRepository repository)
        {
            _repository = repository;
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

        public async Task<IEnumerable<ItemVendaEntity>> GetAll()
        {
            var result = await _repository.SelectAllAsynck();

            if (result == null)
                return null;

            return result;

        }

        public async Task<ItemVendaEntity> GetById(int id)
        {
            var result = await _repository.SelectAsync(id);
            if (result == null)
                return null;

            return result;
        }

        public async Task PostRange(List<ItemVendaEntity> listaItems)
        {
            await _repository.
        }
        public async Task<ItemVendaEntity> Post(ItemVendaEntity item)
        {
            var result = await _repository.InsertAsync(item);
            if (result == null)
                return null;

            return result;
        }

        public async Task<ItemVendaEntity> Put(ItemVendaEntity item)
        {
            var result = await _repository.UpdateAsync(item);
            if (result == null)
                return null;

            return result;
        }
    }
}
