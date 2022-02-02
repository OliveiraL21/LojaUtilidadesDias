using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IVendaRepository : IRepository<VendaEntity>
    {
        public IEnumerable<VendaEntity> GetVendas();
        public IEnumerable<VendaEntity> GetByDate(VendaEntity venda);
        public IEnumerable<VendaEntity> GetByNumber(VendaEntity venda);
        public List<VendaEntity> GetAllNumberVenda();
    }
}
