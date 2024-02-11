using ICI.ProvaCandidato.Dados.Contextos;
using ICI.ProvaCandidato.Dados.Repositorios;
using ICI.ProvaCandidato.Negocio.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ICI.ProvaCandidato.Dados
{
    public static class ProvaCandidatoDadosModulo
    {
        public static IServiceCollection AddModuloDados(this IServiceCollection services, IConfiguration Configuration) 
        {
            services.AddDbContext<AppDbContexto>(options =>
            {
                string connection = Configuration.GetConnectionString("Default");
                options.UseSqlServer(connection);
            });

            services.AddScoped<ITagRepositorio, TagRepositorio>();
            services.AddScoped<INoticiaRepositorio, NoticiaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            return services;
        }
    }
}
