using ICI.ProvaCandidato.Negocio.DTO;
using ICI.ProvaCandidato.Negocio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Contratos.Servicos
{
    public interface ITagServico
    {
        Task<IEnumerable<Tag>> ObterTagsAsync();

        Task<ResultadoDTO> CadastrarAsync(Tag tag);
        Task<Tag> ObterTagPorIdAsync(int value);
        Task<ResultadoDTO> ExcluirTagAsync(int id);
    }
}
