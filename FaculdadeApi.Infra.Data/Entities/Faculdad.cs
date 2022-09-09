using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeApi.Infra.Data.Entities
{
    public class Faculdad
    {
        public Guid IdAluno { get; set; }
        public string Aluno { get; set; }
        public string Turma { get; set; }
        public string Professor { get; set; }
        public string Materias { get; set; }
    }
}
