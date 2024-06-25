using System.Collections.Generic;
using System.Threading.Tasks;   
using Loja.Data;
using loja.models;
using Microsoft.EntityFrameworkCore;

namespace loja.services
{
    public class FornecedorService
    {
        private readonly LojaDbContext _dbContext;

        public FornecedorService(LojaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Método para consultar todos os fornecedores
        public async Task<List<Fornecedor>> GetAllFornecedoresAsync()
        {
            return await _dbContext.Fornecedores.ToListAsync();
        }

        // Método para consultar um fornecedor a partir do seu id
        public async Task<Fornecedor> GetFornecedorByIdAsync(int id)
        {
            return await _dbContext.Fornecedores.FindAsync(id);
        }

        // Método para adicionar um novo fornecedor
        public async Task AddFornecedorAsync(Fornecedor fornecedor)
        {
            _dbContext.Fornecedores.Add(fornecedor);
            await _dbContext.SaveChangesAsync();
        }

        // Método para atualizar um fornecedor
        public async Task UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            _dbContext.Entry(fornecedor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Método para excluir um fornecedor
        public async Task DeleteFornecedorAsync(int id)
        {
            var fornecedor = await _dbContext.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _dbContext.Fornecedores.Remove(fornecedor);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
