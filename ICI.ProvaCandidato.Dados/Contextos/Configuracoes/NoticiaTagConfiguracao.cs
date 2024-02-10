using ICI.ProvaCandidato.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Dados.Contextos.Configuracoes
{
    public class NoticiaTagConfiguracao : IEntityTypeConfiguration<NoticiaTag>
    {
        public void Configure(EntityTypeBuilder<NoticiaTag> builder)
        {
            builder.ToTable("NoticiaTag");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Noticia)
                .WithMany(noticia => noticia.NoticiaTags)
                .HasForeignKey(x => x.NoticiaId);

            builder.HasOne(x => x.Tag)
                .WithMany(tag => tag.NoticiaTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}
