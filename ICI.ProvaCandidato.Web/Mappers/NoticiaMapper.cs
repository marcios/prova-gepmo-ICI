using ICI.ProvaCandidato.Negocio.Entidades;
using ICI.ProvaCandidato.Web.Models.Noticias;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Mappers
{
    public static class NoticiaMapper
    {
        public static Noticia ToEntidade(this NoticiaModel model)
        {
            var noticia = new Noticia
            {
                Id = model.Id.HasValue ? model.Id.Value : 0,
                Texto = model.Texto,
                UsuarioId = model.UsuarioId,
                Titulo = model.Titulo,

            };


            if (model.Tags != null && model.Tags.Any())
            {
                noticia.NoticiaTags = model.Tags.Select(tag => new NoticiaTag
                {
                    TagId = tag.Id.Value,
                    Tag = new Tag
                    {
                        Id = tag.Id.Value,
                        Descricao = tag.Descricao
                    }
                }).ToList();
            }

            return noticia;
        }
    }
}
