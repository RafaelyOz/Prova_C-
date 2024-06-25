
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using loja.models;
using Loja.Data;
namespace loja.services
{
    public class ContratoService
    {
        private readonly LojaDbContext _context;

        public ContratoService(LojaDbContext context)
        {
            _context = context;
        }

        public async Task AddContratoAsync(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();
        }

        public async Task<Contrato> GetContratoByIdAsync(int id)
        {
            return await _context.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Servico)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Contrato>> GetAllContratosAsync()
        {
            return await _context.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Servico)
                .ToListAsync();
        }

        public async Task<List<Contrato>> GetContratosByClienteIdAsync(int clienteId)
        {
            return await _context.Contratos
                .Include(c => c.Servico)
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();
        }
    }
}
