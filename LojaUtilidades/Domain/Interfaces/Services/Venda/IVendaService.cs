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
        public Entidades.Venda Insert(Entidades.Venda venda);
        public Entidades.Venda GetVendaAsync(int id);
        public IEnumerable<Entidades.Venda> GetVendas();
        public IEnumerable<Entidades.Venda> GetByDate(Entidades.Venda venda);
        public IEnumerable<Entidades.Venda> GetByCodigo(Entidades.Venda venda);
        public IEnumerable<Entidades.Venda> GetByProductName(string produto);
        public IEnumerable<Entidades.Venda> GetAllAsync();
        public Entidades.Venda Update(Entidades.Venda venda);
        public bool Delete(int id);
    }
}
