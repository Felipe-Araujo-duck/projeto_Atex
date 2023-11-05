using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Atex.Data.Entity
{
    public class Crianca
    {
        public int IdCrianca { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public int IdResponsavel { get; set; }
        public int IdEscola { get; set; }
        public List<string> JogoRedeSocial { get; set; }
        public List<string> OutroJogoRedeSocial { get; set; }
    }
}
