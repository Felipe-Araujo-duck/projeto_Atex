using Projeto_Atex.Data;
using Projeto_Atex.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Atex
{
    public partial class cadastro : MetroFramework.Forms.MetroForm
    {
        public cadastro()
        {
            InitializeComponent();
            responsavel = new Responsavel();
            crianca = new Crianca();
            questionario = new Questionario();
            _tools = new DataTools();
        }
        private DataTools _tools;
        private Responsavel responsavel;
        public Crianca crianca;
        public Questionario questionario;

        private void button1_Click(object sender, EventArgs e)
        {
            responsavel.Nome = txtNomeResponsavel.Text;
            responsavel.Telefone = txtTelefone.Text;
            responsavel.Email = txtEmail.Text;
            crianca.Nome = txtNome.Text;
            crianca.DataNascimento = DateTime.Parse(dataNascimento.Text).ToString("yyyy-MM-dd");
            crianca.IdEscola = int.Parse(cbEscola.SelectedValue.ToString());
            if (cbMonitoramento.Equals("Sim"))
                questionario.RecebeMonitoramento = 1;

            questionario_Tempo Qt = new questionario_Tempo(responsavel, questionario, crianca);
            Qt.ShowDialog();
        }

        private void cadastro_Load(object sender, EventArgs e)
        {
            var sql = "SELECT idEscola, nome FROM Escola";
            SqlConnection _connection = _tools.ConnectionDB();
            DataSet set = _tools.DbSet(sql, _connection);
            cbEscola.DisplayMember = "nome";
            cbEscola.ValueMember = "idEscola";
            cbEscola.DataSource = set.Tables[0];
        }
    }
}
