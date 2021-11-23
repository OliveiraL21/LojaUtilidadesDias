using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IITemVendaService 
    {
        public Task<ItemVendaEntity> Post(ItemVendaEntity item);
        public Task<ItemVendaEntity> GetById(int id);
        public Task<IEnumerable<ItemVendaEntity>> GetAll();
        public Task<ItemVendaEntity>Put(ItemVendaEntity item);
        public Task<bool> Delete(int id);



    }
}
