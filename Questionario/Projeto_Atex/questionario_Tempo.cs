using Projeto_Atex.Data;
using Projeto_Atex.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Atex
{
    public partial class questionario_Tempo : MetroFramework.Forms.MetroForm
    {
        public questionario_Tempo(Responsavel responsavel, Questionario questionario, CriancaQuestionario crianca)
        {
            InitializeComponent();
            this.responsavel = responsavel;
            this.questionario = questionario;
            this.crianca = crianca;
            _tools = new DataTools();
            _connection = _tools.ConnectionDB();
        }
        private SqlConnection _connection;
        private DataTools _tools;
        public Responsavel responsavel;
        public Questionario questionario;
        public CriancaQuestionario crianca;

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (ckOutrasRedes.Checked)
            {
                label5.Visible = true;
                txtNomeOutraRede.Visible = true;
            }else
            {
                label5.Visible = false;
                txtNomeOutraRede.Visible = false;
            }
        }

        private void checkBox9_Click(object sender, EventArgs e)
        {
            if (ckOutrosJogos.Checked)
            {
                label8.Visible = true;
                txtOutrosJogos.Visible = true;
            }
            else
            {
                label8.Visible = false;
                txtOutrosJogos.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InserirResponsavel();
            InserirCrianca();
            if (cbInternet.Text.Equals("Sim"))
                questionario.AcessoInternet = 1;
            if(cbPossuiCelular.Text.Equals("Sim"))
                questionario.PossuiCelularProprio = 1;
            questionario.TempoUsoDiario = int.Parse(textBox1.Text);
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");

            int idCrianca;
            string sqlCrianca = $"SELECT TOP(1) idCrianca FROM Crianca WHERE idResponsavel='{crianca.IdResponsavel}'";
            SqlCommand cmdCri = _tools.GetCommand(sqlCrianca, _connection);
            _connection.Open();
            SqlDataReader readert = cmdCri.ExecuteReader();
            readert.Read();
            idCrianca = int.Parse(readert["idCrianca"].ToString());
            _connection.Close();
            crianca.IdCrianca = idCrianca;

            string sql = $"INSERT INTO Questionario (idCrianca, dataQuestionario, possuiCelularProprio, acessoInternet, tempoUsoDiario, recebeMonitoramento) VALUES ('{idCrianca}', '{dateNow}', '{questionario.PossuiCelularProprio}', '{questionario.AcessoInternet}', '{questionario.TempoUsoDiario}', '{questionario.RecebeMonitoramento}')";
            _tools.ExecuteNonQuery(sql);

            int idQuestionario;
            string sqlQuestionario = $"SELECT TOP(1) idQuestionario FROM Questionario WHERE idCrianca='{idCrianca}'";
            SqlCommand cmd = _tools.GetCommand(sqlQuestionario, _connection);
            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            idQuestionario = int.Parse(reader["idQuestionario"].ToString());
            _connection.Close();

            InsertJogoRedesSociais(idQuestionario);
            InsertOutrosJogosRedeSocial(idQuestionario);
            MessageBox.Show("Questionário finalizado com sucesso!");
            Program.FC.Close();
            Close();

        }

        private void InserirResponsavel()
        {
            string sql = $"INSERT INTO Responsavel (nome, email, telefone) values ('{responsavel.Nome}', '{responsavel.Email}', '{responsavel.Telefone}')";
            _tools.ExecuteNonQuery(sql);
        }

        private void InserirCrianca()
        {
            string sqlResponsavel = $"SELECT TOP(1) idResponsavel FROM Responsavel WHERE nome='{responsavel.Nome}' and telefone='{responsavel.Telefone}' and email='{responsavel.Email}'";
            SqlCommand cmd = _tools.GetCommand(sqlResponsavel, _connection);
            _connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            crianca.IdResponsavel = int.Parse(reader["idResponsavel"].ToString());
            _connection.Close();
            string sql = $"INSERT INTO Crianca (nome, dataNascimento,idResponsavel, idEscola) values ('{crianca.Nome}', '{crianca.DataNascimento}', '{crianca.IdResponsavel}', '{crianca.IdEscola}')";
            _tools.ExecuteNonQuery(sql);
        }

        private void InsertJogoRedesSociais(int idQuestionario)
        {
            List<int> aux = new List<int>();
            if (ckYoutube.Checked)
                aux.Add(2);
            if(ckTikTok.Checked)
                aux.Add(1);
            if(ckFreeFire.Checked)
                aux.Add(3);
            if(ckStumble.Checked)
                aux.Add(4);
            if(ckRoblox.Checked)
                aux.Add(5);
            if(ckMinecraft.Checked)
                aux.Add(6);
            if(ckSubway.Checked)
                aux.Add(7);

            foreach(var item in aux)
            {
                string sql = $"INSERT INTO CriancaJogoRedeSocial (idJogoRedeSocial, idQuestionario) values ('{item}', '{idQuestionario}')";
                _tools.ExecuteNonQuery(sql);
            }
        }

        public void InsertOutrosJogosRedeSocial(int idQuestionario)
        {
            if(ckOutrosJogos.Checked)
            {
                string sql = $"INSERT INTO OutroJogoRedeSocial (nome, tipo, idQuestionario) VALUES('{txtOutrosJogos.Text}', 'Jogo', '{idQuestionario}')";
                _tools.ExecuteNonQuery(sql);
            }
            if (ckOutrasRedes.Checked)
            {
                string sql = $"INSERT INTO OutroJogoRedeSocial (nome, tipo, idQuestionario) VALUES('{txtNomeOutraRede.Text}', 'Rede Social', '{idQuestionario}')";
                _tools.ExecuteNonQuery(sql);
            }
        }
    }
}
