using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Atex.Data.Entity
{
    public class Questionario
    {
        public int IdQuestionario { get; set; }
        public int IdCrianca { get; set; }
        public DateTime DataQuestionario { get; set; }
        public int PossuiCelularProprio { get; set; }
        public int AcessoInternet { get; set; }
        public int TempoUsoDiario { get; set; }
        public int RecebeMonitoramento { get; set; }
        public int IdOutroJogoRedeSocial { get; set; }
        public int IdCriancaJogoRedeSocial { get; set; }
    }
}
