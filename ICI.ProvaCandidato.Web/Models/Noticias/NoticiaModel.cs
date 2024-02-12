using ICI.ProvaCandidato.Negocio.Entidades;
using ICI.ProvaCandidato.Web.Models.Tags;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Web.Models.Noticias
{
    public class NoticiaModel
    {
        public NoticiaModel()
        {

        }

        public NoticiaModel(Noticia noticia, bool temTag = false)
        {
            this.Id = noticia.Id;
            this.Titulo = noticia.Titulo;
            this.Texto = noticia.Texto;
            this.UsuarioId = noticia.UsuarioId;
            this.TemTag = temTag;

            if (noticia.Usuario != null)
                this.Usuario = noticia.Usuario.Nome;

            if (noticia.NoticiaTags != null && noticia.NoticiaTags.Any())
            {
                AdicionarTags(noticia.NoticiaTags.Select(x => x.Tag), selecioando: true);
            }
        }

        public void AdicionarTags(IEnumerable<Tag> tags, bool selecioando = false)
        {
            if (tags != null && tags.Any())
                this.Tags = tags.Select(tag => new TagModel(tag.Id, tag.Descricao) { Seleciocionado = selecioando }).ToList();
        }

        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public List<TagModel> Tags { get; set; } = new List<TagModel>();

        public bool TemTag { get; set; }
    }
}
