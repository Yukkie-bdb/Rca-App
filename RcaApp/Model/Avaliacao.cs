using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcaApp.Model
{
    public class Avaliacao
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Comentario { get; set; }
        public int Estrelas { get; set; }
    }
}
