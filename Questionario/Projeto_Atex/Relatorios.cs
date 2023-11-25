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
using System.Windows.Forms.DataVisualization.Charting;

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

            Title title = new Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.ForeColor = Color.Black;
            title.Text = "Crianças Por Escola";
            grafico.Titles.Add(title);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Relatorios_Load(object sender, EventArgs e)
        {
            _tools = new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            DataSet ds = new DataSet();
            ds = _tools.DbSet("Select nome From Escola", conn);
            cmbEscola.DisplayMember = "nome";
            cmbEscola.ValueMember = "idEscola";
            cmbEscola.DataSource = ds.Tables[0];
        }

        private void cmbEscola_SelectedIndexChanged(object sender, EventArgs e)
        {
            gerarGraficos(cmbEscola.Text);
        }

        private void gerarGraficos(string escola)
        {
            grafico.Series.Clear();

            grafico.Series.Add("Escolas");
            grafico.Series["Escolas"].LegendText = "Escolas";

            SqlConnection conn = _tools.ConnectionDB();

            int teste = _tools.GetJogadoresPorEscolaPorJogo(escola, "Youtube");
            string testeCMBEscola = cmbEscola.SelectedText;

            grafico.ChartAreas[0].AxisY.Interval = 1;

            grafico.Series["Escolas"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            grafico.Series["Escolas"].BorderWidth = 4;
            grafico.Series["Escolas"].Points.AddXY("TikTok", _tools.GetJogadoresPorEscolaPorJogo(escola, "TikTok"));
            grafico.Series["Escolas"].Points.AddXY("Youtube", _tools.GetJogadoresPorEscolaPorJogo(escola, "Youtube"));
            grafico.Series["Escolas"].Points.AddXY("Free Fire", _tools.GetJogadoresPorEscolaPorJogo(escola, "Free Fire"));
            grafico.Series["Escolas"].Points.AddXY("Stumble Guys", _tools.GetJogadoresPorEscolaPorJogo(escola, "Stumble Guys"));
            grafico.Series["Escolas"].Points.AddXY("Roblox", _tools.GetJogadoresPorEscolaPorJogo(escola, "Roblox"));
            grafico.Series["Escolas"].Points.AddXY("Minecraft", _tools.GetJogadoresPorEscolaPorJogo(escola, "Minecraft"));
            grafico.Series["Escolas"].Points.AddXY("Subway Surfers", _tools.GetJogadoresPorEscolaPorJogo(escola, "Subway Surf"));
            grafico.Series["Escolas"].Points.AddXY("Outros", _tools.GetJogadoresPorEscolaOutroJogoRedeSocial(escola));
        }
    }
}
