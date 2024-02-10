using ICI.ProvaCandidato.Dados.Contextos;
using ICI.ProvaCandidato.Negocio.Contratos.Repositorios;
using ICI.ProvaCandidato.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repositorios
{
    public class TagRepositorio : ITagRepositorio
    {
        private readonly AppDbContexto _contexto;
        public TagRepositorio(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Tag>> ObterTagsAsync()
        {
            return await this._contexto.Tags.ToListAsync();
        }
    }
}
