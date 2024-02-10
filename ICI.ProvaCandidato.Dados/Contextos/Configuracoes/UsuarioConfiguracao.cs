using ICI.ProvaCandidato.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Contextos.Configuracoes
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(x => x.Senha)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
