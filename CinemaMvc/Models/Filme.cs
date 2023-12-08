using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMvc.Models
{
    public class Filme
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AnoLancamento { get; set; }
        public string Categoria { get; set; }
        public string ClassificacaoIndicativa { get; set; }
        public long IdiomaId { get; set; }
        public Idioma idioma { get; set; }
        public virtual ICollection<Idioma> Idiomas { get; set; }
        public virtual ICollection<Atuacao> Atuacoes { get; set; }

    }
}
