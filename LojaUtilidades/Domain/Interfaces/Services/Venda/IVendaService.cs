using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Venda
{
   public interface IVendaService
    {
        public Task<Entidades.Venda> PostAsync(Entidades.Venda venda);
        public Task<Entidades.Venda> GetAsync(int id);
        public IEnumerable<Entidades.Venda> GetVendas();
        public IEnumerable<Entidades.Venda> GetByDate(Entidades.Venda venda);
        public IEnumerable<Entidades.Venda> GetByNumber(Entidades.Venda venda);
        public IEnumerable<Entidades.Venda> GetByProductName(string produto);
        public Task<IEnumerable<Entidades.Venda>> GetAllAsync();
        public Task<Entidades.Venda> PutAsync(Entidades.Venda venda);
        public Task<bool> Delete(int id);
    }
}
