using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Projeto_Atex.Data;
using Projeto_Atex.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Atex
{
    public partial class Relatorios : MetroFramework.Forms.MetroForm
    {
        public Relatorios()
        {
            InitializeComponent();
            lstCriancas.View = View.Details;
            lstCriancas.LabelEdit = true;
            lstCriancas.AllowColumnReorder = true;
            lstCriancas.FullRowSelect = true;

            lstCriancas.Columns.Add("", 0);
            lstCriancas.Columns.Add("Nome", 95, HorizontalAlignment.Center);
            lstCriancas.Columns.Add("Data Questionário", 120, HorizontalAlignment.Center);
            lstCriancas.Columns.Add("Possui Celular", 100, HorizontalAlignment.Center);
            lstCriancas.Columns.Add("Acesso Internet", 110, HorizontalAlignment.Center);
            lstCriancas.Columns.Add("Tempo de Uso Horas", 130, HorizontalAlignment.Center);
            lstCriancas.Columns.Add("Monitoramento", 100, HorizontalAlignment.Center);
            lstCriancas.Columns.Add("Jogos Redes Sociais", 180, HorizontalAlignment.Center);
            lstCriancas.Columns.Add("Outros Jogos Redes S.", 180, HorizontalAlignment.Center);

        }

        public DataTools _tools;

        public CriancaQuestionario c;

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            lstCriancas.Items.Clear();
            lstCriancas.GridLines = false;
            _tools = new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            List<CriancaQuestionario> list = new List<CriancaQuestionario>();
            list = _tools.AtualizarDbSet(conn);
            string listaJogosRedesSociais = "NULL";
            string listaOutrosJogosRedesSociais = "NULL";
            foreach (var crianca in list)
            {
                if (crianca.JogoRedeSocial != null)
                    listaJogosRedesSociais = string.Join(", ", crianca.JogoRedeSocial);
                if (crianca.OutroJogoRedeSocial != null)
                    listaOutrosJogosRedesSociais = string.Join(", ", crianca.OutroJogoRedeSocial);

                string[] row = { "", crianca.Nome, crianca.DataQuestionario.ToString(), crianca.PossuiCelularProprioGet, crianca.AcessoInternetGet, crianca.TempoUsoDiario.ToString(), crianca.RecebeMonitoramentoGet, listaJogosRedesSociais, listaOutrosJogosRedesSociais};
                var listViewItem = new ListViewItem(row);
                lstCriancas.Items.Add(listViewItem);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            lstCriancas.Items.Clear();
            lstCriancas.GridLines = false;
            _tools = new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            List<CriancaQuestionario> list = new List<CriancaQuestionario>();
            list = _tools.PesquisarDbSet(conn, txtPesquisa.Text);
            string listaJogosRedesSociais = "NULL";
            string listaOutrosJogosRedesSociais = "NULL";
            foreach (var crianca in list)
            {
                if (crianca.JogoRedeSocial != null)
                    listaJogosRedesSociais = string.Join(", ", crianca.JogoRedeSocial);
                if (crianca.OutroJogoRedeSocial != null)
                    listaOutrosJogosRedesSociais = string.Join(", ", crianca.OutroJogoRedeSocial);

                string[] row = { "", crianca.Nome, crianca.DataQuestionario.ToString(), crianca.PossuiCelularProprioGet, crianca.AcessoInternetGet, crianca.TempoUsoDiario.ToString(), crianca.RecebeMonitoramentoGet, listaJogosRedesSociais, listaOutrosJogosRedesSociais };
                var listViewItem = new ListViewItem(row);
                lstCriancas.Items.Add(listViewItem);
            }
        }
    }
}
