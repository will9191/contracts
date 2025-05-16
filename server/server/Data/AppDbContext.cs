using Microsoft.EntityFrameworkCore;
using server.Entities;

namespace server.Data
{
    // Contexto do banco de dados usado pelo Entity Framework Core,
    // que representa uma sessão com o banco e permite consultar e salvar entidades.
    // Funciona como uma abstração do repositório para as entidades User e Contract.
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractFile> ContractFiles { get; set; }
    }
}
