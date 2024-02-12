using ICI.ProvaCandidato.Negocio.Entidades;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Contratos.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObterPorId(int id);
    }
}
