using agenda_api.Model;
using Microsoft.EntityFrameworkCore;

namespace agenda_api.Infrastructure
{
    public class ConnectionContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;" +
                "Database=agenda;" +
                "Username=postgres;" + // Usuário correto
                "Password=postgres"

                );
        }

        public DbSet<Contato> contatos { get; set; }

    }
}
