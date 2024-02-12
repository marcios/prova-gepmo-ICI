using ICI.ProvaCandidato.Negocio.Entidades;
using ICI.ProvaCandidato.Web.Models.Tags;
using System;

namespace ICI.ProvaCandidato.Web.ViewModels
{
    public class TagCadastroViewModel
    {
        public TagModel Tag { get; set; }

        public string Mensagem { get; set; }
        public bool Sucesso { get; set; } = true;

        public TagCadastroViewModel()
        {
            
        }
        public TagCadastroViewModel(Tag tag)
        {
            this.Tag = new TagModel(tag.Id, tag.Descricao);
        }

        internal void AdicionarErro(string mensagem)
        {
            this.Mensagem = mensagem;
            this.Sucesso = false;
        }
    }
}
