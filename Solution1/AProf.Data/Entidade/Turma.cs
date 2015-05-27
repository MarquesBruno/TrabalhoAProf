using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AProf.Data.Entidade
{
    public class Turma
    {
        public int id { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_termino { get; set; }
        public Curso curso_id { get; set; }
        public Professor professor_id { get; set; }
    }
}
