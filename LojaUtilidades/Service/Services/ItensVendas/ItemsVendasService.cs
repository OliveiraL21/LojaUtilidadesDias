using Domain.Entidades;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.ItensVendas
{
    public class ItemsVendasService : IITemVendaService
    {
        private readonly IITemVendaService _repository;
        public ItemsVendasService(IITemVendaService repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _repository.Delete(id);
                return false;
            }
            catch
            {
                throw;
            }
        }

        public Task<IEnumerable<ItemVendaEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ItemVendaEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemVendaEntity> Post(ItemVendaEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<ItemVendaEntity> Put(ItemVendaEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
