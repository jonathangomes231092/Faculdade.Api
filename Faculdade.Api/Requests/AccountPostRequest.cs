using System.ComponentModel.DataAnnotations;

namespace Faculdade.Api.Requests
{
    public class AccountPostRequest
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o login do usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme a senha do usuário")]
        public string SenhaConfirmacao { get; set; }
    }
}
