using ICI.ProvaCandidato.Negocio.Constantes;
using ICI.ProvaCandidato.Negocio.Contratos.Servicos;
using ICI.ProvaCandidato.Web.Mappers;
using ICI.ProvaCandidato.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly INoticiaServico _noticiaServico;
        private readonly ITagServico _tagServico;
        public NoticiasController(INoticiaServico noticiaServico, ITagServico tagServico)
        {
            this._noticiaServico = noticiaServico;
            _tagServico = tagServico;
        }
        public async Task<IActionResult> Index()
        {
            var noticias = await this._noticiaServico.ObterNoticiasAsync();
            var model = new NoticiaIndexViewModel(noticias);
            return View(model);
        }

        public async Task<IActionResult> Cadastro(int? id = null)
        {
            NoticiaCadastroViewModel model = null;
            var tags = await this._tagServico.ObterTagsAsync();
            if (id.HasValue && id.Value > 0)
            {
                var noticia = await this._noticiaServico.ObterNoticiaPorIdAsync(id.Value);
                model = new NoticiaCadastroViewModel(noticia);
                model.AddTags(tags);
                model.RelacionarTags();

            }
            else
            {
                model = new NoticiaCadastroViewModel();
                model.AddTags(tags);
                model.Noticia.UsuarioId = UsuarioPadrao.ID_USUARIO_PADRAO;
            }



            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(NoticiaCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.ConverterTagsSelecionadas();
                var noticia = model.Noticia.ToEntidade();

                var resultado = await this._noticiaServico.CadastrarAsync(noticia);

                if (resultado.Sucesso)
                    return RedirectToAction("Index");


                StringBuilder sb = new StringBuilder();
                resultado.Erros.ForEach(erro => sb.Append($"{erro} <br>"));
                model.AdicionarErro(sb.ToString());


            }

            return View(model);
        }

        public async Task<JsonResult> Excluir(int id)
        {
            var resultado = await this._noticiaServico.ExcluirAsync(id);
            return new JsonResult(resultado);
        }
    }
}
