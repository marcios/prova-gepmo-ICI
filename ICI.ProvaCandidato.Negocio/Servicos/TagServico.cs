using ICI.ProvaCandidato.Negocio.Contratos.Repositorios;
using ICI.ProvaCandidato.Negocio.Contratos.Servicos;
using ICI.ProvaCandidato.Negocio.DTO;
using ICI.ProvaCandidato.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Negocio.Servicos
{
    public class TagServico : ITagServico
    {
        private readonly ITagRepositorio _tagRepositorio;
        public TagServico(ITagRepositorio tagRepositorio)
        {
            _tagRepositorio = tagRepositorio;
        }

        public async Task<ResultadoDTO> CadastrarAsync(Tag tag)
        {
            var resultado = ValidarCadastro(tag);
            if (!resultado.Sucesso) return resultado;

            if(tag.Id <= 0)
            {
                resultado = await AdicionarTagAsync(tag);
            }
            else
            {
                resultado = await AtualizarTagAsync(tag);
            }

            return resultado;
        }

        private async Task<ResultadoDTO> AtualizarTagAsync(Tag tag)
        {
            var resultado = new ResultadoDTO();

            try
            {
                await this._tagRepositorio.AtualizarAsync(tag);
            }
            catch (Exception ex)
            {
                resultado.Erros.Add($"Falha ao atualizar a TAG {tag.Descricao}: ({ex.Message})");
            }
            return resultado;
        }

        private async Task<ResultadoDTO> AdicionarTagAsync(Tag tag)
        {
            var resultado = new ResultadoDTO();
            try
            {
                await this._tagRepositorio.AdicionarAsync(tag);
            }
            catch (Exception ex)
            {
                resultado.Erros.Add($"Falha ao adicionar uma nova TAG ({ex.Message})");
            }
            return resultado;
        }

        private ResultadoDTO ValidarCadastro(Tag tag)
        {
            var resultado = new ResultadoDTO();

            if (string.IsNullOrWhiteSpace(tag.Descricao))
            {
                resultado.Erros.Add("A descrição não pode ser vazia!");
            }

            return resultado;
        }

        public async Task<IEnumerable<Tag>> ObterTagsAsync()
        {
            return await this._tagRepositorio.ObterTagsAsync();
        }

        public async Task<Tag> ObterTagPorIdAsync(int id)
        {
            return await this._tagRepositorio.ObterPorIdAsync(id);
        }

        public async Task<ResultadoDTO> ExcluirTagAsync(int id)
        {
            var resultado = await ValidarExclusaoAsync(id);

            if (!resultado.Sucesso) return resultado;

            try
            {
                var tag = resultado.Retorno as Tag;
                await this._tagRepositorio.ExcluirAsync(tag);
                resultado.AdicionarMensagem($"Tag {tag.Descricao} removida com sucesso.");
                resultado.Retorno = null;
            }
            catch (Exception ex)
            {

                resultado.Erros.Add($"Não foi possível excluir a tag. Motivo: {ex.Message}");
            }
            return resultado;
        }

        private async Task<ResultadoDTO> ValidarExclusaoAsync(int id)
        {
            var resultado = new ResultadoDTO();
            var tag = await this._tagRepositorio.ObterPorIdAsync(id);

            if(tag == null)
            {
                resultado.Erros.Add($"Tag com id {id} não existe!");
                return resultado;
            }

            if (tag.NoticiaTags.Any())
            {
               resultado.Erros.Add($"Não é possível excluir uma tag com notícia(s) vinculada(s).");
                return resultado;
            }

            resultado.Retorno = tag;

            return resultado; 
        }
    }
}
