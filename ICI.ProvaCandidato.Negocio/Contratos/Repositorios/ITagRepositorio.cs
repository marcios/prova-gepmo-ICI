using ICI.ProvaCandidato.Negocio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Contratos.Repositorios
{
    public interface ITagRepositorio
    {
        Task AdicionarAsync(Tag tag);
        Task AtualizarAsync(Tag tag);
        Task ExcluirAsync(Tag tag);
        Task<Tag> ObterPorIdAsync(int id);
        Task<IEnumerable<Tag>> ObterTagsAsync();
        Task<IEnumerable<Tag>> ObterTagsAsync(IEnumerable<int> tagsIds);
    }
}
