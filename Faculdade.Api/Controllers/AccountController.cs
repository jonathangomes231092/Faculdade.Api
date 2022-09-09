using Faculdade.Api.Requests;
using FaculdadeApi.Infra.Data.Entities;
using FaculdadeApi.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Faculdade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
       private readonly IUsuarioRepository _usuarioRepository;
        
       
        public AccountController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost]
        public IActionResult Post(AccountPostRequest request)
        {

            try
            {
                //var criptografia = new Criptografia();
                //realizar o cadastro do usuário
                var usuario = new Usuario()
                {
                    IdUsuario = Guid.NewGuid(),
                    Nome = request.Nome,
                    Login = request.Login,
                    Senha = request.Senha,//criptografia.GetMD5(request.Senha)
                };
                _usuarioRepository.Inserir(usuario);
                //HTTP 201 (CREATED)
                return StatusCode(201, new
                {
                    mensagem = $"Parabéns { usuario.Nome}, sua conta foi criada com sucesso."});
            }
            catch (Exception e)
            {
                //HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { mensagem = e.Message });

            }
        }
    }
}
