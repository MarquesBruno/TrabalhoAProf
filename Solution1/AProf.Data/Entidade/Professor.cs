using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AProf.Data.Entidade
{
    public class Professor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public decimal valor_hora_aula { get; set; }
    }
}
