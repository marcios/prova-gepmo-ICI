using ICI.ProvaCandidato.Dados.Contextos;
using ICI.ProvaCandidato.Negocio.Contratos.Repositorios;
using ICI.ProvaCandidato.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repositorios
{
    public class NoticiaRepositorio : INoticiaRepositorio
    {
        private readonly AppDbContexto _contexto;

        public NoticiaRepositorio(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task CadastrarAsync(Noticia noticia)
        {
            this._contexto.Noticias.Add(noticia);
            await this._contexto.SaveChangesAsync();

        }

        public async Task AtualizarAsync(Noticia noticia)
        {
            await this._contexto.SaveChangesAsync();

        }

        public async Task<IEnumerable<Noticia>> ObterNoticiasAsync()
        {
            return await this._contexto.Noticias
                .Include(noticia => noticia.NoticiaTags)
                    .ThenInclude(noticiaTag => noticiaTag.Tag)
                 .Include(noticia => noticia.Usuario)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Noticia> ObterPorIdAsync(int id)
        {
            return await this._contexto.Noticias
                    .Include(noticia => noticia.NoticiaTags)
                        .ThenInclude(noticiaTag => noticiaTag.Tag)
                    .Include(noticia => noticia.Usuario)
                    .FirstOrDefaultAsync(noticia => noticia.Id == id);
        }

        public async Task ExcluirAsync(Noticia noticia)
        {
            this._contexto.Noticias.Remove(noticia);
            await this._contexto.SaveChangesAsync();
        }
    }
}
