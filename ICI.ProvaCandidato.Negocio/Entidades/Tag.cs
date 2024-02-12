﻿using System.Collections.Generic;

namespace ICI.ProvaCandidato.Negocio.Entidades
{
    public class Tag
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<NoticiaTag> NoticiaTags { get; set; } = new List<NoticiaTag>();
    }
}
