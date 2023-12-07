using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMvc.Models
{
    public class Atuacao
    {
 
        public long Id { get; set; }
        public long AtorId { get; set; }
        public long FilmeId { get; set; }
        public virtual ICollection<Ator> Atores { get; set; }
        public virtual ICollection<Filme> Filmes { get; set; }
        public Ator ator { get; set; }
        public Filme filme { get; set; }

    }
}