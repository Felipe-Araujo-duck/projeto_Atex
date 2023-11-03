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

    }
}
