using ICI.ProvaCandidato.Dados.Contextos.Configuracoes;
using ICI.ProvaCandidato.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ICI.ProvaCandidato.Dados.Contextos
{
    public class AppDbContexto : DbContext
    {
        public DbSet<Tag> Tags { get; set; }

        public AppDbContexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new TagConfiguracao());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagConfiguracao).Assembly);
        }
    }
}
