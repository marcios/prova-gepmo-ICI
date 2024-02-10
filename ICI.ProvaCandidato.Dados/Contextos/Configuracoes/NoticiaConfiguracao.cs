using ICI.ProvaCandidato.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Dados.Contextos.Configuracoes
{
    public class NoticiaConfiguracao : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.ToTable("Noticia");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.Texto)
                .HasColumnType("text")
                .IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
