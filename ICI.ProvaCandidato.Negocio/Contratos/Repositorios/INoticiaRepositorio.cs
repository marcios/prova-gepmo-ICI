using ICI.ProvaCandidato.Negocio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Contratos.Repositorios
{
    public interface INoticiaRepositorio
    {
        Task CadastrarAsync(Noticia noticia);
        Task AtualizarAsync(Noticia noticia);

        Task<Noticia> ObterPorIdAsync(int id);

        Task<IEnumerable<Noticia>> ObterNoticiasAsync();
        Task ExcluirAsync(Noticia noticia);
    }
}
