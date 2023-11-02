using Projeto_Atex.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Atex
{
    public partial class questionario_Tempo : MetroFramework.Forms.MetroForm
    {
        public questionario_Tempo(Responsavel responsavel, Questionario questionario, Crianca crianca)
        {
            InitializeComponent();
            this.responsavel = responsavel;
            this.questionario = questionario;
            this.crianca = crianca;
        }
        public Responsavel responsavel;
        public Questionario questionario;
        public Crianca crianca;
        public CriancaJogoRedeSocial criancaJogoRedeSocial;

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
            if (cbInternet.Text == "Sim")
                questionario.AcessoInternet = true;


            MessageBox.Show("Questionário finalizado com sucesso!");
            Program.FC.Close();
            Close();

        }
    }
}
