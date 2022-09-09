using System.ComponentModel.DataAnnotations;

namespace Faculdade.Api.Requests
{
    public class LoginPostRequest
    {
        [Required(ErrorMessage = "Por favor, informe o login de acesso.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        public string Senha { get; set; }

    }
}
