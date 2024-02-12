using System;
using System.Collections.Generic;
using System.Linq;

namespace ICI.ProvaCandidato.Negocio.DTO
{
    public class ResultadoDTO
    {
        public bool Sucesso
        {
            get
            {
                return !Erros.Any();
            }
        }
        public List<string> Erros { get; set; } = new List<string>();
        public object Retorno { get; set; }
        public string Mensagem { get; private set; }

        internal void AdicionarMensagem(string mensagem)
        {
            this.Mensagem = mensagem;
        }
    }
}
