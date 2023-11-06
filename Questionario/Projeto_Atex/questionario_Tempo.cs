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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Impedir que a vírgula seja digitada mais de uma vez
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
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
            if(!string.IsNullOrWhiteSpace(cbPossuiCelular.Text) && !string.IsNullOrWhiteSpace(cbInternet.Text) 
                && (ckYoutube.Checked || ckTikTok.Checked || ckOutrasRedes.Checked)
                && (ckMinecraft.Checked || ckFreeFire.Checked || ckRoblox.Checked || ckStumble.Checked || ckSubway.Checked || ckOutrosJogos.Checked))
            {
                if(ckOutrasRedes.Checked && ckOutrosJogos.Checked)
                {
                    if(!string.IsNullOrWhiteSpace(txtNomeOutraRede.Text) && !string.IsNullOrWhiteSpace(txtOutrosJogos.Text))
                    {
                        double valorDouble = ConvertToDouble(textBox1.Text);

                        if (valorDouble != -1)
                        {
                            MessageBox.Show("Questionário finalizado com sucesso!");
                            Program.FC.Close();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Hora fora do intervalo permitido (0 a 23.59).");
                        }
                    } else
                    {
                        MessageBox.Show("Preencha o campo nome de outras redes sociais e outros jogos.");
                    }
                }
                else if(ckOutrasRedes.Checked)
                {
                    if (!string.IsNullOrWhiteSpace(txtNomeOutraRede.Text))
                    {
                        double valorDouble = ConvertToDouble(textBox1.Text);

                        if (valorDouble != -1)
                        {
                            MessageBox.Show("Questionário finalizado com sucesso!");
                            Program.FC.Close();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Hora fora do intervalo permitido (0 a 23.59).");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha o campo nome de outras redes sociais.");
                    }
                    
                }
                else if (ckOutrosJogos.Checked)
                {
                    if (!string.IsNullOrWhiteSpace(txtOutrosJogos.Text))
                    {
                        double valorDouble = ConvertToDouble(textBox1.Text);

                        if (valorDouble != -1)
                        {
                            MessageBox.Show("Questionário finalizado com sucesso!");
                            Program.FC.Close();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Hora fora do intervalo permitido (0 a 23.59).");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha o campo nome de outros jogos.");
                    }
                }
                else
                {
                    double valorDouble = ConvertToDouble(textBox1.Text);

                    if (valorDouble != -1)
                    {
                        MessageBox.Show("Questionário finalizado com sucesso!");
                        Program.FC.Close();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Hora fora do intervalo permitido (0 a 23.59).");
                    }
                }

            }
            else
                MessageBox.Show("Há campos não preenchidos!");
        }

        
        private double ConvertToDouble(string horaInput)
        {
            if (double.TryParse(horaInput, out double valorDouble))
            {
                string[] parts = horaInput.Split(new[] { ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    int hours = int.Parse(parts[0]);
                    int minutes = int.Parse(parts[1]);
                    var aux = parts[1].Split('0');
                    if (aux[0] != "")
                    {
                        minutes = minutes < 10 && minutes > 5 ? minutes * 10 : minutes;
                    } 

                    if (hours < 24 && minutes < 60)
                    {
                        return valorDouble;
                    }



                }
                else if(parts.Length == 1)
                {
                    int hours = int.Parse(parts[0]);
                    if (hours < 24)
                    {
                        return valorDouble;
                    }
                }
                else
                {
                    return -1;
                }
            }

            return -1.0; // Valor inválido
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
