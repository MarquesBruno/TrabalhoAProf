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
    public class CursoRepositorio
    {
        public static List<Curso> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            
            MySqlCommand cmd = new MySqlCommand();
           
            List<Curso> cursos = new List<Curso>();



            // sql.Append("select IdConta, QtdKwMes, max(QtdKwMes) ");
            sql.Append("select * ");
            sql.Append("From cursos ");
            sql.Append("order by nome asc");


            
            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = Chocolate.Get(cmd);

            // MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                cursos.Add(
                    new Curso
                    {

                        id = (int)dr["id"],
                        carga_horaria = (int)dr["carga_horaria"],
                        conteudo_prog = (string)dr["conteudo_prog"],
                        nome = (string)dr["nome"],
                        valor = (double)dr["valor"]
                        

                    });
            }

            //maximo = sql.Append("select * from maximo");
            //SELECT * FROM vwProdutos
            dr.Close();
            return cursos;
        }


        public static void Create(Curso pCurso)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("insert into cursos (carga_horaria, conteudo_prog, nome, valor)");
            sql.Append("value (@carga_horaria, @conteudo_prog, @nome, @valor)");


            cmd.Parameters.AddWithValue("@carga_horaria", pCurso.carga_horaria);
            cmd.Parameters.AddWithValue("@conteudo_prog", pCurso.conteudo_prog);
            cmd.Parameters.AddWithValue("@nome", pCurso.nome);
            cmd.Parameters.AddWithValue("@valor", pCurso.valor);
            

            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Chocolate.CommandPersist(cmd);


        }

        public static void Delete(int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM cursos where id=@id");


            cmd.Parameters.AddWithValue("@id", id);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Chocolate.CommandPersist(cmd);


        }


        public static void Edit(Curso pCurso)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update cursos ");
            sql.Append("set carga_horaria=@carga_horaria, conteudo_prog=@conteudo_prog, nome=@nome, valor=@valor ");
            sql.Append("where id=@id");

            cmd.Parameters.AddWithValue("@id", pCurso.id);
            cmd.Parameters.AddWithValue("@carga_horaria", pCurso.carga_horaria);
            cmd.Parameters.AddWithValue("@conteudo_prog", pCurso.conteudo_prog);
            cmd.Parameters.AddWithValue("@nome", pCurso.nome);
            cmd.Parameters.AddWithValue("@valor", pCurso.valor);
            

            cmd.CommandText = sql.ToString();

            Chocolate.CommandPersist(cmd);
        }

        public static object GetOne(int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("select * ");
            sql.Append("From cursos "); //Não esquecer de criar Banco no Wamp 
            sql.Append("Where id=@id");
            //Ulltimo acesso as 2:54 da manha do dia 14/04/2015
            //Continuar daqui...

            cmd.Parameters.AddWithValue("@id", id);
            //

            //

            Curso curso;
            cmd.CommandText = sql.ToString();
            //MySqlDataReader dr = Conexao.Get(sql.ToString());
            MySqlDataReader dr = Chocolate.Get(cmd);

            dr.Read();

            curso = new Curso
            {


                id = (int)dr["id"],
                carga_horaria = (int)dr["carga_horaria"],
                conteudo_prog = (string)dr["conteudo_prog"],
                nome = (string)dr["nome"],
                valor = (double)dr["valor"],


            };
            dr.Close();
            return curso;

        }

    }
}
