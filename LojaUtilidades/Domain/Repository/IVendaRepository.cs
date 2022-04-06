using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IVendaRepository : IRepository<Venda>
    {
        public IEnumerable<Venda> GetVendas();
        public IEnumerable<Venda> GetByDate(Venda venda);
        public IEnumerable<Venda> GetByNumber(Venda venda);
        public IEnumerable<Venda> GetByProductName(string produto);
        public List<Venda> GetAllNumberVenda();
    }
}
