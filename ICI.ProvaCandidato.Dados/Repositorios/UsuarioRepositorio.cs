using ICI.ProvaCandidato.Dados.Contextos;
using ICI.ProvaCandidato.Negocio.Contratos.Repositorios;
using ICI.ProvaCandidato.Negocio.Entidades;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Dados.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContexto _contexto;

        public UsuarioRepositorio(AppDbContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuario>ObterPorId(int id)
        {
            return await this._contexto.Usuarios.FindAsync(id);
        }
    }
}
