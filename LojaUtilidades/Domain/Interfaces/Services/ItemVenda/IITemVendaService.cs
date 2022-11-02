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
        public Task<ItemVenda> Insert(ItemVenda item);
        public ItemVenda GetById(int id);
        public IEnumerable<ItemVenda> GetItens();
        public Task<ItemVenda>Update(ItemVenda item);
        public Task<bool> Delete(int id);



    }
}
