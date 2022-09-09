
using System;
using System.ComponentModel.DataAnnotations;

namespace Faculdade.API.Request
{
    public class FaculdadePutRequest
    {
        [Required(ErrorMessage = "Por favor, informe o ID do aluno")]
        public Guid IdAluno { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do aluno")]
        public string Aluno { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do professor")]
        public string Professor { get; set; }

        [MinLength(4, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(10, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a turma do aluno")]
        public string Turma { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1}caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a matrícula do aluno")]
        public string Materias { get; set; }




    }
}
