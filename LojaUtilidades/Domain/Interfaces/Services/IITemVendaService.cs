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
        public Task<ItemVenda> Post(ItemVenda item);
        public Task<ItemVenda> GetById(int id);
        public Task<IEnumerable<ItemVenda>> GetAll();
        public Task<ItemVenda>Put(ItemVenda item);
        public Task<bool> Delete(int id);



    }
}
