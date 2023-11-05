using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Atex.Data.Entity
{
    public class CriancaQuestionario
    {

        private int possuicelularproprio;
        public int PossuiCelularProprioSet
        {
            set { possuicelularproprio = value; }
        }
        public string PossuiCelularProprioGet
        {
            get
            {
                if (possuicelularproprio == 1)
                    return "Sim";
                else
                    return "Não";
            }
        }

        private int acessointernet;
        public int AcessoInternetSet
        {
            set { acessointernet = value; }        
        }
        public string AcessoInternetGet
        {
            get
            {
                if (acessointernet == 1)
                    return "Sim";               
                else
                    return "Não";
            }
        }

        private int recebemonitoramento;
        public int RecebeMonitoramentoSet
        {
            set { recebemonitoramento = value; }
        }
        public string RecebeMonitoramentoGet
        {
            get
            {
                if (recebemonitoramento == 1)
                    return "Sim";
                else
                    return "Não";
            }
        }

        public int TempoUsoDiario { get; set; }
        public int IdCrianca { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string DataQuestionario { get; set; }
        public int IdResponsavel { get; set; }
        public int IdEscola { get; set; }
        public List<string> JogoRedeSocial { get; set; }
        public List<string> OutroJogoRedeSocial { get; set; }
    }
}
