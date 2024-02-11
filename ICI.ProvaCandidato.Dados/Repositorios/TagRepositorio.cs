using ICI.ProvaCandidato.Dados.Contextos;
using ICI.ProvaCandidato.Negocio.Contratos.Repositorios;
using ICI.ProvaCandidato.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AdicionarAsync(Tag tag)
        {
            this._contexto.Tags.Add(tag);
            await this._contexto.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tag tag)
        {
            this._contexto.Entry(tag).State = EntityState.Modified;
            await this._contexto.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Tag tag)
        {
            this._contexto.Tags.Remove(tag);
            await this._contexto.SaveChangesAsync();
        }

        public async Task<Tag> ObterPorIdAsync(int id)
        {
            return await this._contexto.Tags.Include(tag => tag.NoticiaTags).FirstOrDefaultAsync(tag => tag.Id == id);

        }

        public async Task<IEnumerable<Tag>> ObterTagsAsync()
        {
            return await this._contexto.Tags
                .Include(tag => tag.NoticiaTags)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tag>> ObterTagsAsync(IEnumerable<int> tagsIds)
        {
            return await this._contexto.Tags
                .AsNoTracking()
                .Where(tag=>tagsIds.Contains(tag.Id))
                .ToListAsync();
        }
    }
}
