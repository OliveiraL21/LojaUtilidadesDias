using Data.Context;
using Data.Implementation;
using Domain.Entidades;
using Domain.Interfaces.Services.Produtos;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Produtos
{
    public class ProdutoService :  IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) 
        {
            _repository = repository;
        }
        public ProdutoService()
        {
            _repository = new ProdutoImplementation(new MyContext(new DbContextOptions<MyContext>()));
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProdutoEntity> Get(int id)
        {
            try
            {
                var result = await _repository.SelectAsync(id);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProdutoEntity>> GetAll()
        {
            try
            {
                var result = await _repository.SelectAllAsynck();
                return result;
            }
            catch
            {
                throw;
            }
        }


        public async Task<ProdutoEntity> Post(ProdutoEntity produto)
        {
            try
            {
                var result = await _repository.InsertAsync(produto);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProdutoEntity> Put(ProdutoEntity produto)
        {
            try
            {
                var result = await _repository.UpdateAsync(produto);
                return result;

            }
            catch
            {
                throw;
            }
        }

    }
}
