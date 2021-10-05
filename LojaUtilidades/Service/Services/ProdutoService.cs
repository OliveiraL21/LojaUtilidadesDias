using Domain.Entity;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<Produto> GetByName(string name)
        {
            return await _repository.SelectByName(name);
        }

        public async Task<Produto> Post(Produto produto)
        {
            return await _repository.InsertAsync(produto);
        }

        public async Task<Produto> Put(Produto produto)
        {
            return await _repository.UpdateAsync(produto);
        }
    }
}
