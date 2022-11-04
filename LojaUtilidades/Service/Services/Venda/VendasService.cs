using Data.Context;
using Data.Implementation;
using Domain.Entidades;
using Domain.Interfaces.Services.Venda;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Services.Venda
{
   public class VendasService : IVendaService
    {
        public readonly IVendaRepository _repository;
        public VendasService(IVendaRepository repository)
        {
            _repository = repository;
        }
        public VendasService()
        {
            _repository = new VendaImplementation(new MyContext());
        }

        private int GenerateVendaCode(Domain.Entidades.Venda venda)
        {
            try
            {
                var result = _repository.GetAllNumberVenda();
                if (result == null || result.Count == 0)
                {
                    venda.Codigo = 1000;
                    return venda.Codigo;
                }
                var lastNumber = result.Last();
                int number = lastNumber.Codigo;
                number += 1;
                return number;

            }
            catch 
            {
                throw ;
            }


        }
        public  bool Delete(int id)
        {
            return  _repository.DeleteAsync(id);
        }

        public  IEnumerable<Domain.Entidades.Venda> GetAllAsync()
        {
            var result =  _repository.SelectAllAsync();
            return result;   
        }
        public Domain.Entidades.Venda GetVendaAsync(int id)
        {
            var result =  _repository.SelectAsync(id);
            return result;
        }

        public IEnumerable<Domain.Entidades.Venda> GetVendas()
        {
            var result =  _repository.GetVendas();
            return result;
        }

        public IEnumerable<Domain.Entidades.Venda> GetByDate(Domain.Entidades.Venda venda)
        {
            var result = _repository.GetByDate(venda);
            return result;
        }
        public IEnumerable<Domain.Entidades.Venda> GetByCodigo(Domain.Entidades.Venda venda)
        {
            var result = _repository.GetByNumber(venda);
            return result;
        }
        public IEnumerable<Domain.Entidades.Venda> GetByProductName(string produto)
        {
            var result = _repository.GetByProductName(produto);
            return result;
        }
        public Domain.Entidades.Venda Insert(Domain.Entidades.Venda venda)
        {
            venda.Codigo = GenerateVendaCode(venda);
            var result =  _repository.InsertAsync(venda);
            
            return result;
        }

        public Domain.Entidades.Venda Update(Domain.Entidades.Venda venda)
        {
            var result =  _repository.UpdateAsync(venda);
            return result;
         }

       
    }
}
