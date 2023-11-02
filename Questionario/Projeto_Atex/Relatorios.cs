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
            lstCriancas.GridLines = true;

            lstCriancas.Columns.Add("Nome", 100, HorizontalAlignment.Left);
            lstCriancas.Columns.Add("Data Questionário", 100, HorizontalAlignment.Left);
            lstCriancas.Columns.Add("Possui Celular", 50, HorizontalAlignment.Left);
            lstCriancas.Columns.Add("Acesso Internet", 50, HorizontalAlignment.Left);
            lstCriancas.Columns.Add("Tempo de Uso", 100, HorizontalAlignment.Left);
            lstCriancas.Columns.Add("Monitoramento", 50, HorizontalAlignment.Left);
            lstCriancas.Columns.Add("Jogos Redes Sociais", 270, HorizontalAlignment.Left);
        }

        public DataTools _tools;

        public Crianca c;

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            _tools = new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            List<Crianca> list = new List<Crianca>();
            list = _tools.PesquisaDbSet(conn);
            string listaJogosRedesSociais = "NULL";
            foreach (var crianca in list)
            {
                if (crianca.JogoRedeSocial != null)
                    listaJogosRedesSociais = string.Join(", ", crianca.JogoRedeSocial);

                string[] row = { crianca.Nome, crianca.DataNascimento.ToString(), "Sim", "Sim", "Sim", "Sim", listaJogosRedesSociais };
                var listViewItem = new ListViewItem(row);
                lstCriancas.Items.Add(listViewItem);
            }
        }
    }
}
