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
    public class TurmaRepositorio
    {
        public static List<Turma> GetAll()
        {
            StringBuilder sql = new StringBuilder();

            MySqlCommand cmd = new MySqlCommand();

            List<Turma> turma = new List<Turma>();



            // sql.Append("select IdConta, QtdKwMes, max(QtdKwMes) ");
            sql.Append("select * ");
            sql.Append("From turmas ");
            sql.Append("order by id asc");



            cmd.CommandText = sql.ToString();

            MySqlDataReader dr = Chocolate.Get(cmd);

            // MySqlDataReader dr = Conexao.Get(sql.ToString());

            while (dr.Read())
            {
                turma.Add(
                    new Turma
                    {

                        id = (int)dr["id"],
                        data_inicio = (DateTime)dr["data_inicio"],
                        data_termino = (DateTime)dr["data_termino"],
                        curso_id = (Curso)dr["curso_id"],
                        professor_id = (Professor)dr["professor_id"]



                    });
            }

            //maximo = sql.Append("select * from maximo");
            //SELECT * FROM vwProdutos
            dr.Close();
            return turma;
        }


        public void Create(Turma pTurma)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("insert into turmas (data_inicio, data_termino, curso_id,professor_id)");
            sql.Append("value (@data_inicio, @data_termino, @curso_id, @professor_id)");


            cmd.Parameters.AddWithValue("@data_inicio", pTurma.data_inicio);
            cmd.Parameters.AddWithValue("@data_termino", pTurma.data_termino);
            cmd.Parameters.AddWithValue("@curso_id", pTurma.curso_id.id);
            cmd.Parameters.AddWithValue("@professor_id", pTurma.professor_id.id);



            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Chocolate.CommandPersist(cmd);


        }

        public void Delete(Turma pTurma, int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("DELETE FROM turmas where id=@id");


            cmd.Parameters.AddWithValue("@id", pTurma.id);


            cmd.CommandText = sql.ToString();

            //passando o command para a dll conn resolver a persistência
            Chocolate.CommandPersist(cmd);


        }


        public void Edit(Turma pTurma)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();
            sql.Append("update turmas ");
            sql.Append("set data_inicio=@data_inicio, data_termino=@data_termino, curso_id=@curso_id, professor_id=@professor_id");
            sql.Append("where id=@id");

            cmd.Parameters.AddWithValue("@data_inicio", pTurma.data_inicio);
            cmd.Parameters.AddWithValue("@data_termino", pTurma.data_termino);
            cmd.Parameters.AddWithValue("@curso_id", pTurma.curso_id.id);
            cmd.Parameters.AddWithValue("@professor_id", pTurma.professor_id.id);

            cmd.CommandText = sql.ToString();

            Chocolate.CommandPersist(cmd);
        }

        internal static object GetOne(int id)
        {
            StringBuilder sql = new StringBuilder();
            MySqlCommand cmd = new MySqlCommand();

            sql.Append("select * ");
            sql.Append("From turmas "); //Não esquecer de criar Banco no Wamp 
            sql.Append("Where id=@id");
            //Ulltimo acesso as 2:54 da manha do dia 14/04/2015
            //Continuar daqui...

            cmd.Parameters.AddWithValue("@id", id);
            //

            //

            Turma turma;
            cmd.CommandText = sql.ToString();
            //MySqlDataReader dr = Conexao.Get(sql.ToString());
            MySqlDataReader dr = Chocolate.Get(cmd);

            dr.Read();

            turma = new Turma
            {


                id = (int)dr["id"],
                data_inicio = (DateTime)dr["data_inicio"],
                data_termino = (DateTime)dr["data_termino"],
                curso_id = (Curso)dr["curso_id"],
                professor_id = (Professor)dr["professor_id"]


            };
            dr.Close();
            return turma;

        }
    }
}
