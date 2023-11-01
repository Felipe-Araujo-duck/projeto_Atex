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

namespace Projeto_Atex
{
    public partial class Relatorios : MetroFramework.Forms.MetroForm
    {
        public Relatorios()
        {
            InitializeComponent();
        }

        public DataTools _tools;

        private void tbnPesquisar_Click(object sender, EventArgs e)
        {
            _tools = new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            gridCrianca.DataSource = _tools.DbSet("Select * from Crianca",conn);
        }
    }
}
