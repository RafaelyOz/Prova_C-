using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using loja.models;
using Loja.Data;

namespace loja.services
{
    public class ServicoService
    {
        private readonly LojaDbContext _context;

        public ServicoService(LojaDbContext context)
        {
            _context = context;
        }

        public async Task AddServicoAsync(Servico servico)
        {
            _context.Servicos.Add(servico);
            await _context.SaveChangesAsync();
        }

        public async Task<Servico> GetServicoByIdAsync(int id){
            return await _context.Servicos.FindAsync(id);
        }

        public async Task UpdateServicoAsync(Servico servico){
            _context.Servicos.Update(servico);
            await _context.SaveChangesAsync();
        }

       
    }
}
