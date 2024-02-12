using System.ComponentModel.DataAnnotations;

namespace ICI.ProvaCandidato.Web.Models.Tags
{
    public class TagModel
    {
        
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public bool TemNoticias { get; set; }
        public bool Seleciocionado { get; set; }    


        public TagModel(int id, string descricao, bool temNoticias = false)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.TemNoticias = temNoticias;
        }

        public TagModel()
        {
            
        }
    }


}
