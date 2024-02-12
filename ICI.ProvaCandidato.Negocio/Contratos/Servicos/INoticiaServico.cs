using ICI.ProvaCandidato.Negocio.DTO;
using ICI.ProvaCandidato.Negocio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Contratos.Servicos
{
    public interface INoticiaServico
    {
        Task<ResultadoDTO> CadastrarAsync(Noticia noticia);
        Task<IEnumerable<Noticia>> ObterNoticiasAsync();

        Task<Noticia> ObterNoticiaPorIdAsync(int id);
        Task<ResultadoDTO> ExcluirAsync(int id);
    }
}
