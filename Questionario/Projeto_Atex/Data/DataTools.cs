using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Atex.Data.Entity;
using System.Reflection;

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

        public int GetJogadoresPorEscolaPorJogo(string escola, string jogo)
        {
            int resultado = 0;
            DataTools _tools = new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            conn.Open();

            SqlCommand command = new SqlCommand("Select Count(cjrs.idCriancaJogoRedeSocial) " +
                "from CriancaJogoRedeSocial cjrs " +
                "inner join JogoRedeSocial jrs on jrs.idJogoRedeSocial = cjrs.idJogoRedeSocial " +
                "inner join Questionario q on q.idQuestionario = cjrs.idQuestionario " +
                "inner join Crianca c on c.idCrianca = q.idCrianca " +
                "inner join Escola e on e.idEscola = c.idEscola " +
                $"where e.nome = '{escola}' and jrs.nome = '{jogo}' " +
                "group by jrs.nome", conn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                resultado = reader.GetInt32(0);
            }
            return resultado;
        }

        public int GetJogadoresPorEscolaOutroJogoRedeSocial(string escola)
        {
            int resultado = 0;
            DataTools _tools = new DataTools();
            SqlConnection conn = _tools.ConnectionDB();
            conn.Open();

            SqlCommand command = new SqlCommand("select count(ojrs.idOutroJogoRedeSocial) " +
                "from OutroJogoRedeSocial ojrs " +
                "inner join Questionario q on q.idQuestionario = ojrs.idQuestionario " +
                "inner join Crianca c on c.idCrianca = q.idCrianca " +
                "inner join Escola e on e.idEscola = c.idEscola " +
                $"where e.nome = '{escola}' group by e.nome", conn);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                resultado = reader.GetInt32(0);
            }
            return resultado;
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

        public List<CriancaQuestionario> AtualizarDbSet(SqlConnection conn)
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

        public List<CriancaQuestionario> PesquisarDbSet(SqlConnection conn, string pesquisa)
        {
            CriancaQuestionario c = new CriancaQuestionario();
            conn.Open();
            List<CriancaQuestionario> criancas = new List<CriancaQuestionario>();
            SqlCommand command = new SqlCommand($"Select * From Atualizar Where nome like '%{pesquisa}%'");
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
