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
        public questionario_Tempo()
        {
            InitializeComponent();
        }

        

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                label5.Visible = true;
                textBox2.Visible = true;
            }else
            {
                label5.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void checkBox9_Click(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                label8.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                label8.Visible = false;
                textBox3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Questionário finalizado com sucesso!");
            Program.FC.Close();
            Close();

        }
    }
}
