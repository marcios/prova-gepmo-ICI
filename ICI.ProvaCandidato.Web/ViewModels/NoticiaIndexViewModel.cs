using ICI.ProvaCandidato.Negocio.Entidades;
using ICI.ProvaCandidato.Web.Models.Noticias;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Web.ViewModels
{
    public class NoticiaIndexViewModel
    {
        public NoticiaIndexViewModel()
        {

        }

        public NoticiaIndexViewModel(IEnumerable<Noticia> noticias)
        {
            if (noticias != null && noticias.Any())
            {
                this.Noticias = noticias.Select(noticia => new NoticiaModel(noticia, noticia.NoticiaTags.Any())).ToList();
            }
        }
        public List<NoticiaModel> Noticias { get; set; }
    }
}
