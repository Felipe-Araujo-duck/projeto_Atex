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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projeto_Atex
{
    public partial class cadastro : MetroFramework.Forms.MetroForm
    {
        public cadastro()
        {
            InitializeComponent();
            responsavel = new Responsavel();
            crianca = new CriancaQuestionario();
            questionario = new Questionario();
            _tools = new DataTools();
        }
        private DataTools _tools;
        private Responsavel responsavel;
        public CriancaQuestionario crianca;
        public Questionario questionario;

        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtNomeResponsavel.Text) && !string.IsNullOrWhiteSpace(txtTelefone.Text)
                && !string.IsNullOrWhiteSpace(txtNome.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text)
                && !string.IsNullOrWhiteSpace(cbEscola.Text) && !string.IsNullOrWhiteSpace(cbMonitoramento.Text))
            {
                string email = txtEmail.Text.Trim();

                if (IsValidEmail(email))
                {
                    questionario_Tempo Qt = new questionario_Tempo();
                    Qt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("O endereço de e-mail não é válido.");
                }
                
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
            }
            
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        string AplicarMascaraTelefone(string strNumero)
        {
            // por omissão tem 10 ou menos dígitos
            string strMascara = "{0:(00)0000-0000}";
            // converter o texto em número
            long lngNumero = Convert.ToInt64(strNumero);

            if (strNumero.Length == 11)
                strMascara = "{0:(00)00000-0000}";

            return string.Format(strMascara, lngNumero);
        }

        string RemoverCaracteresDeFormatacao(string numeroFormatado)
        {
            // Remove todos os caracteres não numéricos do número de telefone
            return new string(numeroFormatado.Where(char.IsDigit).ToArray());
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

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            //mandar a variavel textoSemMascara para o banco
            string textoSemMascara = txtTelefone.Text;
            string numeroFormatado = AplicarMascaraTelefone(textoSemMascara);
            txtTelefone.Text = numeroFormatado;
            txtTelefone.SelectionStart = txtTelefone.Text.Length; // Mover o cursor para o final
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // Ignora o caractere se não for um número
            }

            if (txtTelefone.Text.Length >= 11 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Limita o número de dígitos a 11
            }
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            txtTelefone.Text = RemoverCaracteresDeFormatacao(txtTelefone.Text);
        }
    }
}
