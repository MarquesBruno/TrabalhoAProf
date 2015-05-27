using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AProf.Data.Entidade;
using ConnElinhoDAO.MySql;
using MySql.Data.MySqlClient;

namespace AProf.Repository.Repositorio
{
    public class ProfessorRepositorio
    {
        public static List<Professor> GetAll()
        {
            StringBuilder sql = new StringBuilder();

            MySqlCommand cmd = new MySqlCommand();

            List<Professor> professor = new List<Professor>();



            // sql.Append("select IdConta, QtdKwMes, max(QtdKwMes) ");
            sql.Append("select * ");
            sql.Append("From professores ");
            sql.Append("order by nome asc");



            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = Chocolate.Get(cmd);

            // MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                professor.Add(
                    new Professor
                    {

                        id = (int)dr["id"],
                        nome = (string)dr["nome"],
                        telefone = (string)dr["telefone"],
                        valor_hora_aula = (decimal)dr["valor_hora_aula"]
                        


                    });
            }

            //maximo = sql.Append("select * from maximo");
            //SELECT * FROM vwProdutos
            dr.Close();
            return professor;
        }


        public void Create(Professor pProf)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("insert into professores (nome, telefone, valor_hora_aula)");
            sql.Append("value (@nome, @telefone, @valor_hora_aula)");


            cmd.Parameters.AddWithValue("@nome", pProf.nome);
            cmd.Parameters.AddWithValue("@telefone", pProf.telefone);
            cmd.Parameters.AddWithValue("@valor_hora_aula", pProf.valor_hora_aula);
            


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Chocolate.CommandPersist(cmd);


        }

        public void Delete(Professor pProf, int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM professores where id=@id");


            cmd.Parameters.AddWithValue("@id", pProf.id);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Chocolate.CommandPersist(cmd);


        }


        public void Edit(Professor pProf)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update professores ");
            sql.Append("set nome=@nome, telefone=@telefone, valor_hora_aula=@valor_hora_aula");
            sql.Append("where id=@id");

            cmd.Parameters.AddWithValue("@id", pProf.id);
            cmd.Parameters.AddWithValue("@nome", pProf.nome);
            cmd.Parameters.AddWithValue("@telefone", pProf.telefone);
            cmd.Parameters.AddWithValue("@valor_hora_aula", pProf.valor_hora_aula);


            cmd.CommandText = sql.ToString();

            Chocolate.CommandPersist(cmd);
        }

        internal static object GetOne(int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("select * ");
            sql.Append("From professores "); //Não esquecer de criar Banco no Wamp 
            sql.Append("Where id=@id");
            //Ulltimo acesso as 2:54 da manha do dia 14/04/2015
            //Continuar daqui...

            cmd.Parameters.AddWithValue("@id", id);
            //

            //

            Professor professor;
            cmd.CommandText = sql.ToString();
            //MySqlDataReader dr = Conexao.Get(sql.ToString());
            MySqlDataReader dr = Chocolate.Get(cmd);

            dr.Read();

            professor = new Professor
            {


                id = (int)dr["id"],
                nome = (string)dr["nome"],
                telefone = (string)dr["telefone"],
                valor_hora_aula = (decimal)dr["valor_hora_aula"]


            };
            dr.Close();
            return professor;

        }
    }
}
