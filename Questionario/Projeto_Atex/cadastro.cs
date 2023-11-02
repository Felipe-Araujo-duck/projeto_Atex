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
    public partial class cadastro : MetroFramework.Forms.MetroForm
    {
        public cadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            questionario_Tempo Qt = new questionario_Tempo();
            Qt.ShowDialog();
        }

        private void cadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
