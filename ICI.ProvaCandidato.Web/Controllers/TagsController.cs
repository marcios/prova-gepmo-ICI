using ICI.ProvaCandidato.Negocio.Contratos.Servicos;
using ICI.ProvaCandidato.Web.Mappers;
using ICI.ProvaCandidato.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagServico _tagServico;
        public TagsController(ITagServico tagServico)
        {
            _tagServico = tagServico;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await this._tagServico.ObterTagsAsync();

            var viewModel = new TagIndexViewModel(tags);
            return View(viewModel);
        }

        public async Task<IActionResult> Cadastro(int? id = null)
        {
            TagCadastroViewModel model = null;
            if (id.HasValue && id.Value > 0)
            {
                var tag = await this._tagServico.ObterTagPorIdAsync(id.Value);
                if(tag != null)
                {
                    model = new TagCadastroViewModel(tag);
                }
                else
                {
                    model.AdicionarErro($"Não foi localizado uma TAG com id: {id}");
                }
            }
            else
            {
                model = new TagCadastroViewModel();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(TagCadastroViewModel model)
        {

            if (ModelState.IsValid)
            {
                var tag = model.Tag.ToEntidade();
                var resultado = await this._tagServico.CadastrarAsync(tag);

                if (resultado.Sucesso)
                {
                    return RedirectToAction("Index");
                }

                StringBuilder sb = new StringBuilder();
                resultado.Erros.ForEach(erro => sb.Append($"{erro} <br>"));
                model.AdicionarErro(sb.ToString());

            }
        
            //se tiver falha
            return View(model);
        }

        public async Task<JsonResult> Excluir(int id)
        {
            var resultado = await this._tagServico.ExcluirTagAsync(id);
            
            return new JsonResult(resultado);
        }
    }
}
