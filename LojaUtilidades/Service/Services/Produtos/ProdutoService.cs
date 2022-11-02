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

        public Produto GetProduto(int id)
        {
            try
            {
                var result =  _repository.SelectAsync(id);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Produto> GetProdutos()
        {
            try
            {
                var result =  _repository.SelectAllAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }


        public async Task<Produto> Insert(Produto produto)
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

        public async Task<Produto> Update(Produto produto)
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

        public async Task<bool> DeleteByName(string nome)
        {
            try
            {
                var result = await _repository.DeleteByName(nome);
                if(result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
              
            }
            catch
            {
                throw;
            }
        }

        public async Task<Produto> SelectByName(string nome)
        {
            try
            {
                var result = await _repository.SelectByName(nome);
                if(result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
