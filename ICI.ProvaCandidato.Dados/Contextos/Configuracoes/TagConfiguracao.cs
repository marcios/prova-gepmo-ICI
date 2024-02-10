using ICI.ProvaCandidato.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICI.ProvaCandidato.Dados.Contextos.Configuracoes
{
    public class TagConfiguracao : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
