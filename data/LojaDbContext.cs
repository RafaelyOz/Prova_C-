using Microsoft.EntityFrameworkCore;
using loja.models;

namespace Loja.Data
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<ProdutoDeposito> ProdutosDeposito { get; set; }
        public DbSet<Servico> Servicos { get; set; }

        public DbSet<Contrato> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Fornecedor>().HasKey(f => f.Id);
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Venda>().HasKey(v => v.Id);
            modelBuilder.Entity<Deposito>().HasKey(d => d.Id);
            modelBuilder.Entity<Servico>().HasKey(s => s.Id);
            modelBuilder.Entity<Contrato>().HasKey(c => c.Id);
            modelBuilder.Entity<ProdutoDeposito>().HasKey(pd => new { pd.ProdutoId, pd.DepositoId });
            modelBuilder.Entity<Contrato>().HasKey(c => new { c.ClienteId, c.ServicoId });

            modelBuilder.Entity<ProdutoDeposito>()
                        .HasOne(pd => pd.Produto)
                        .WithMany(p => p.ProdutosDeposito)
                        .HasForeignKey(pd => pd.ProdutoId);

            modelBuilder.Entity<ProdutoDeposito>()
                        .HasOne(pd => pd.Deposito)
                        .WithMany(d => d.ProdutosDeposito)
                        .HasForeignKey(pd => pd.DepositoId);

            modelBuilder.Entity<Contrato>()
           .HasOne(c => c.Cliente)
           .WithMany(cliente => cliente.Contratos)
           .HasForeignKey(c => c.ClienteId);

            modelBuilder.Entity<Contrato>()
                        .HasOne(c => c.Servico)
                        .WithMany(servico => servico.Contratos)
                        .HasForeignKey(c => c.ServicoId);
        }
    }
}
