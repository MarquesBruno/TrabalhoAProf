using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AProf.Data.Entidade
{
    public class Curso
    {
        public int id { get; set; }
        public int carga_horaria { get; set; }
        public string conteudo_prog { get; set; }
        public string nome { get; set; }
        public double valor { get; set; }
    }
}
