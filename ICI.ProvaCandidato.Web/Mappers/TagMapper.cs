using ICI.ProvaCandidato.Negocio.Entidades;
using ICI.ProvaCandidato.Web.Models.Tags;

namespace ICI.ProvaCandidato.Web.Mappers
{
    public static class TagMapper
    {
        public static Tag ToEntidade(this TagModel model)
        {
            return new Tag
            {
                Id = model.Id.HasValue ? model.Id.Value : 0,
                Descricao = model.Descricao
            };
        } 
    }
}
