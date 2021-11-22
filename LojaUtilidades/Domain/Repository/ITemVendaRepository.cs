using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
   public interface ITemVendaRepository
    {
        public IList<ItemVendaEntity> GetByName(ItemVendaEntity itemVenda);
    }
}
