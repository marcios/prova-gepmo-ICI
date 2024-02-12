using ICI.ProvaCandidato.Negocio.Entidades;
using ICI.ProvaCandidato.Web.Models.Tags;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Web.ViewModels
{
    public class TagIndexViewModel
    {
        public TagIndexViewModel(IEnumerable<Tag> tags)
        {
            if(tags != null && tags.Any())
            {
                this.Tags = tags.Select(tag => new TagModel(tag.Id, tag.Descricao, tag.NoticiaTags.Any())).ToList();
            }
        }
        public List<TagModel> Tags { get; set; } = new List<TagModel>();
    }
}
