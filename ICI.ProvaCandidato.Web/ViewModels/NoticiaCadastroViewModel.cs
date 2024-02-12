using ICI.ProvaCandidato.Negocio.Entidades;
using ICI.ProvaCandidato.Web.Models.Noticias;
using ICI.ProvaCandidato.Web.Models.Tags;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Web.ViewModels
{
    public class NoticiaCadastroViewModel
    {
        public NoticiaCadastroViewModel()
        {
            this.Noticia = new NoticiaModel();
        }

        public void ConverterTagsSelecionadas()
        {
            try
            {
                var tags = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TagModel>>(this.TagsSelecionadas);
                if (tags != null && tags.Any())
                    this.Noticia.Tags = tags;
            }
            catch
            {

            }
        }

        public NoticiaCadastroViewModel(Noticia noticia)
        {
            this.Noticia = new NoticiaModel(noticia);
        }
        public NoticiaModel Noticia { get; set; }
        public List<TagModel> Tags { get; private set; } = new List<TagModel>();

        public string TagsSelecionadas { get; set; }
        public string Mensagem { get; private set; }
        public bool Sucesso { get; private set; }

        public void AddTags(IEnumerable<Tag> tags)
        {
            if (tags != null && tags.Any())
                this.Tags = tags.Select(tag => new TagModel(tag.Id, tag.Descricao)).ToList();
        }

        public void RelacionarTags()
        {
            if (this.Tags != null && this.Tags.Any())
            {
                var tagsSelecionadas = this.Tags.Where(tag => this.Noticia.Tags.Any(tagNoticia => tagNoticia.Id.Equals(tag.Id))).ToList();
                if (tagsSelecionadas != null)
                    tagsSelecionadas.ForEach(tag => tag.Seleciocionado = true);
            }
        }

        internal void AdicionarErro(string mensagem)
        {
            this.Mensagem = mensagem;
            this.Sucesso = false;
        }
    }
}
