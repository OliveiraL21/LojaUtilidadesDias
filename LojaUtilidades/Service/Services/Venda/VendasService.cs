using Data.Context;
using Data.Implementation;
using Domain.Entidades;
using Domain.Interfaces.Services.Venda;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private int GenerateVendaNumber()
        {
            var result = _repository.GetAllNumberVenda().Last();
            
            int number = result.NumeroVenda;
            number += 1;
            return number;
            
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<VendaEntity>> GetAllAsync()
        {
            var result = await _repository.SelectAllAsynck();
            return result;
            
        }


        public async Task<VendaEntity> GetAsync(int id)
        {
            var result = await _repository.SelectAsync(id);
            return result;
        }

        public IEnumerable<VendaEntity> GetVendas()
        {
            var result =  _repository.GetVendas();
            return result;
        }

        public IEnumerable<VendaEntity> GetByDate(VendaEntity venda)
        {
            var result = _repository.GetByDate(venda);
            return result;
        }
        public IEnumerable<VendaEntity> GetByProductName(string produto)
        {
            var result = _repository.GetByProductName(produto);
            return result;
        }
        public async Task<VendaEntity> PostAsync(VendaEntity venda)
        {

            venda.NumeroVenda = GenerateVendaNumber();
            var result = await _repository.InsertAsync(venda);
            return result;
        }

        public async Task<VendaEntity> PutAsync(VendaEntity venda)
        {
            var result = await _repository.UpdateAsync(venda);
            return result;
         }

       
    }
}
