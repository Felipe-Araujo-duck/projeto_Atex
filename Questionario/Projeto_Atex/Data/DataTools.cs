using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Atex.Data
{
    public class DataTools
    {
        public DataTools()
        {
            Conexao = new SqlConnection();
            Conexao.ConnectionString = "Server =.\\SQLEXPRESS; Database = PII IV; UID = sa; PWD = 123;";
        }
        private SqlConnection Conexao { get; set; }
        public SqlConnection ConnectionDB()
        {
            return Conexao;
        }

        public SqlCommand GetCommand(string sql, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            return cmd;
        }

        public void ExecuteNonQuery(string sql)
        {
            Conexao.Open();
            SqlCommand cmd = GetCommand(sql, Conexao);
            cmd.ExecuteNonQuery();
            Conexao.Close();
        }

        public DataSet DbSet(string sql, SqlConnection conn)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet set = new DataSet();
            adapter.Fill(set);
            conn.Close();
            return set;
        }
    }
}
