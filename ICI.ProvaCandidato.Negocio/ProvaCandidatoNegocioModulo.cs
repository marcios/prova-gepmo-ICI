using ICI.ProvaCandidato.Negocio.Contratos.Servicos;
using ICI.ProvaCandidato.Negocio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace ICI.ProvaCandidato.Negocio
{
    public static class ProvaCandidatoNegocioModulo
	{
		public static IServiceCollection AddProvaCandidatoNegocioModulo(this IServiceCollection services)
		{
			services.AddScoped<ITagServico, TagServico>();
			services.AddScoped<INoticiaServico, NoticiaServico>();
			
			return services;
		}
	}
}
