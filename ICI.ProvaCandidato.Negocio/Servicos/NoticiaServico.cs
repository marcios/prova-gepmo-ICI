using ICI.ProvaCandidato.Negocio.Contratos.Repositorios;
using ICI.ProvaCandidato.Negocio.Contratos.Servicos;
using ICI.ProvaCandidato.Negocio.DTO;
using ICI.ProvaCandidato.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Servicos
{
    public class NoticiaServico : INoticiaServico
    {
        private readonly INoticiaRepositorio _noticiaRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITagRepositorio _tagRepositorio;

        public NoticiaServico(INoticiaRepositorio noticiaRepositorio, IUsuarioRepositorio usuarioRepositorio, ITagRepositorio tagRepositorio)
        {
            _noticiaRepositorio = noticiaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _tagRepositorio = tagRepositorio;
        }

        public async Task<ResultadoDTO> CadastrarAsync(Noticia noticia)
        {
            var resultado = await this.ValidarCadastro(noticia);

            if (!resultado.Sucesso) return resultado;

            if(noticia.Id <= 0)
            {
                resultado = await this.CadastrarNoticiaAsync(noticia);

                
            }else
            {
                resultado = await this.AtualizarNoticiaAsync(noticia);
            }


            return resultado;

        }

        private async Task<ResultadoDTO> AtualizarNoticiaAsync(Noticia noticia)
        {
            var resultado = new ResultadoDTO();

            try
            {
                var noticiaSalva = await this.ObterNoticiaPorIdAsync(noticia.Id);

                this.SincronizarNoticia(noticia, noticiaSalva);
                await this._noticiaRepositorio.AtualizarAsync(noticiaSalva);
                resultado.AdicionarMensagem("Notícia atualizada com sucesso!");
            }
            catch (Exception ex)
            {

                resultado.Erros.Add($"Não foi possível atualizar a notícia. Motivo: ({ex.Message})");
            }

            return resultado;
        }

        private void SincronizarNoticia(Noticia noticia, Noticia noticiaSalva)
        {

            noticiaSalva.Titulo = noticia.Titulo;
            noticiaSalva.UsuarioId = noticia.UsuarioId;
            noticiaSalva.Texto = noticia.Texto;

            var tagsParaRemover = noticiaSalva.NoticiaTags.Where(t => !noticia.NoticiaTags.Any(nt => nt.TagId.Equals(t.TagId))).ToList();
            var tagsParaAdicionar = noticia.NoticiaTags.Where(t => !noticiaSalva.NoticiaTags.Any(nt => nt.TagId.Equals(t.TagId))).ToList();

            tagsParaRemover.ForEach(tagRemover => noticiaSalva.NoticiaTags.Remove(tagRemover));
            tagsParaAdicionar.ForEach(tagAdicionar => noticiaSalva.NoticiaTags.Add(tagAdicionar));
        }

        private async Task<ResultadoDTO> CadastrarNoticiaAsync(Noticia noticia)
        {
            var resultado = new ResultadoDTO();

            try
            {
               LimparTagNoticia(noticia);
                await this._noticiaRepositorio.CadastrarAsync(noticia);
                
                resultado.AdicionarMensagem("Notícia cadastrada com sucesso!");
            }
            catch (Exception ex)
            {

                resultado.Erros.Add($"Não foi possível cadastrar uma nova notícia. Motivo: ({ex.Message})");
            }

            return resultado;
        }

        private void LimparTagNoticia(Noticia noticia)
        {
            //remover o objeto tag
            if(noticia.NoticiaTags!=null)
            {
                foreach(var noticiaTag in noticia.NoticiaTags)
                {
                    noticiaTag.Tag = null;
                }
            }
        }

        private async Task<ResultadoDTO> ValidarCadastro(Noticia noticia)
        {
            var resultado = new ResultadoDTO();

            if(string.IsNullOrWhiteSpace(noticia.Titulo))
            {
                resultado.Erros.Add("Informe o título");
                return resultado;
            }


            if (string.IsNullOrWhiteSpace(noticia.Texto))
            {
                resultado.Erros.Add("Informe o texto");
                return resultado;
            }


            if(noticia.UsuarioId <=0)
            {
                resultado.Erros.Add("Usuário não foi informado");
                return resultado;
            }else
            {
                var usuario = await this._usuarioRepositorio.ObterPorId(noticia.UsuarioId);
                if(usuario == null)
                {
                    resultado.Erros.Add("Usuário informado não existe.");
                }
            }


            if(noticia.NoticiaTags!=null && noticia.NoticiaTags.Any())
            {
                //buscar as tags existentes pelo id
                var tags = await this._tagRepositorio.ObterTagsAsync(noticia.NoticiaTags.Select(t => t.TagId));
                if(tags == null)
                {
                    resultado.Erros.Add("Tags fornecidas não localizadas");
                    return resultado;
                }

                var diffTags = noticia.NoticiaTags.Where(tag=> !tags.Any(t=>t.Id.Equals(tag.TagId))).ToList();
                if(diffTags.Any()) 
                {
                    string nomesTags = String.Join(", ", diffTags.Select(t => t.Tag.Descricao));
                    resultado.Erros.Add($"Tag(s) {nomesTags} não localizada(s)");
                    return resultado;
                }
                
            }

  

            return resultado;
        }

        public async Task<IEnumerable<Noticia>> ObterNoticiasAsync()
        {
            return await this._noticiaRepositorio.ObterNoticiasAsync();
        }

        public async Task<Noticia> ObterNoticiaPorIdAsync(int id)
        {
            return await this._noticiaRepositorio.ObterPorIdAsync(id);
        }

        public async Task<ResultadoDTO> ExcluirAsync(int id)
        {
            var resultado =  await this.ValidarExclusaoAsync(id);
            if (!resultado.Sucesso) return resultado;

            var noticia = resultado.Retorno as Noticia;

            try
            {
                await this._noticiaRepositorio.ExcluirAsync(noticia);
                resultado.AdicionarMensagem("Notícia excluída com sucesso");
            }
            catch (Exception ex)
            {

                resultado.Erros.Add($"Não foi possível excluir a notícia '{noticia.Titulo}' motivo: (${ex.Message})");
            }

            return resultado;

        }

        private async Task<ResultadoDTO> ValidarExclusaoAsync(int id)
        {
            var resultado = new ResultadoDTO();
            var noticia = await this._noticiaRepositorio.ObterPorIdAsync(id);

            if (noticia == null)
            {
                resultado.Erros.Add($"Notícia com id {id} não existe!");
                return resultado;
            }

            if (noticia.NoticiaTags.Any())
            {
                resultado.Erros.Add($"Não é possível excluir uma Notícia com tag(s) vinculada(s).");
                return resultado;
            }

            resultado.Retorno = noticia;

            return resultado;
        }
    }
}
