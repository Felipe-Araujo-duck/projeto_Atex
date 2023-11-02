using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Atex.Data.Entity;

namespace Projeto_Atex.Data
{
    public class DataTools
    {
        public DataTools()
        {
            Conexao = new SqlConnection();
            Conexao.ConnectionString = "Server =.\\SQLEXPRESS; Database = PII IV; UID = sa; PWD = Jp28072002;";
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

        public List<string> GetJogoRedeSocials(int idCrianca) 
        {
            DataTools _tools= new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            conn.Open();
            List<string> jrs = new List<string>();
            SqlCommand command = new SqlCommand($"select cr.idCrianca, jr.nome " +
                $"from JogoRedeSocial jr " +
                $"inner join CriancaJogoRedeSocial cr on cr.idJogoRedeSocial = jr.idJogoRedeSocial " +
                $"where cr.idCrianca = {idCrianca}");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                jrs.Add(reader.GetString(1));
            }
            conn.Close();
            return jrs;
        }

        public List<Crianca> PesquisaDbSet(SqlConnection conn)
        {
            Crianca c = new Crianca();
            conn.Open();
            List<Crianca> criancas= new List<Crianca>();
            SqlCommand command = new SqlCommand("Select * From Crianca");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                c = new Crianca();
                c.IdCrianca = reader.GetInt32(0);           
                c.Nome = reader.GetString(1);
                c.DataNascimento = reader.GetDateTime(2);
                c.IdResponsavel = reader.GetInt32(3);
                c.IdEscola = reader.GetInt32(4);
                c.JogoRedeSocial = GetJogoRedeSocials(c.IdCrianca);
                criancas.Add(c);
            }
            conn.Close();
            return criancas;
        }
    }
}
