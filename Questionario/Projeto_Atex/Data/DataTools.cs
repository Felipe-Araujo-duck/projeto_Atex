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

        public List<string> GetOutroJogoRedeSocial(int idCrianca)
        {
            DataTools _tools = new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            conn.Open();
            List<string> list = new List<string>();
            SqlCommand command = new SqlCommand($"select cr.idCrianca, ojr.nome " +
                $"from OutroJogoRedeSocial ojr " +
                $"inner join Questionario q on ojr.idQuestionario = q.idQuestionario " +
                $"inner join Crianca cr on cr.idCrianca = q.idCrianca " +
                $"where cr.idCrianca = {idCrianca}");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(1));
            }
            conn.Close();
            return list;
        }

        public List<string> GetJogoRedeSociais(int idCrianca) 
        {
            DataTools _tools= new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            conn.Open();
            List<string> jrs = new List<string>();
            SqlCommand command = new SqlCommand($"select cr.idCrianca, jr.nome " +
                $"from JogoRedeSocial jr " +
                $"inner join CriancaJogoRedeSocial cjr on cjr.idJogoRedeSocial = jr.idJogoRedeSocial " +
                $"inner join Questionario q on cjr.idQuestionario = q.idQuestionario " +
                $"inner join Crianca cr on cr.idCrianca = q.idCrianca " +
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

        public List<CriancaQuestionario> AltualizarDbSet(SqlConnection conn)
        {
            CriancaQuestionario c = new CriancaQuestionario();
            conn.Open();
            List<CriancaQuestionario> criancas= new List<CriancaQuestionario>();
            SqlCommand command = new SqlCommand("Select * From Atualizar");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                c = new CriancaQuestionario();
                c.IdCrianca = reader.GetInt32(0);           
                c.Nome = reader.GetString(1);
                c.DataQuestionario = reader.GetDateTime(2).ToString("dd/MM/yyyy");
                c.PossuiCelularProprioSet = reader.GetInt16(3);
                c.AcessoInternetSet = reader.GetInt16(4);
                c.TempoUsoDiario = reader.GetInt32(5);
                c.RecebeMonitoramentoSet = reader.GetInt32(6);
                c.JogoRedeSocial = GetJogoRedeSociais(c.IdCrianca);
                c.OutroJogoRedeSocial = GetOutroJogoRedeSocial(c.IdCrianca);
                if (criancas.Any(x => x.IdCrianca == c.IdCrianca))
                    continue;
                else
                    criancas.Add(c);
            }
            conn.Close();
            return criancas;
        }
    }
}
