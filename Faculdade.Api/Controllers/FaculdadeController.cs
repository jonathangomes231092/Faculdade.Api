using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using FaculdadeApi.Infra.Data.Interfaces;
using FaculdadeApi.Infra.Data.Repositories;
using Faculdade.API.Request;
using FaculdadeApi.Infra.Data.Entities;

namespace Faculdade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaculdadeController : ControllerBase
    {
        private readonly IFaculdadeRepository _faculdadeRepository;
        
        public FaculdadeController(IFaculdadeRepository faculdadeRepository)
        {
            _faculdadeRepository = faculdadeRepository;
        }
            
        [HttpPost]
        public IActionResult Post(FaculdadePostRequest requests)
        {
            try
            {
                var faculdad = new Faculdad()
                
                {
                    IdAluno = Guid.NewGuid(),
                    Aluno = requests.Aluno,
                    Turma = requests.Turma,
                    Materias = requests.Materias,
                    Professor = requests.Professor

                        

                };
                _faculdadeRepository.Inserir(faculdad);


                return StatusCode(201,
                    new { mensagem = $"Aluno {faculdad.Aluno}, cadastrado com sucesso" });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });

            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(FaculdadePutRequest requests)
        {
            try 
            {
                var faculdad = _faculdadeRepository.ObterPorId(requests.IdAluno);
                if (faculdad == null)
                    return StatusCode(422, new { mensagem = "Id Invalido." });

                faculdad.Aluno = requests.Aluno;
                faculdad.Turma = requests.Turma;   
                faculdad.Materias = requests.Materias;
                faculdad.Professor=requests.Professor;

                _faculdadeRepository.Alterar(faculdad);

                return StatusCode(201,
                    new { mensagem = $"Aluno {faculdad.Aluno}, atualizado com sucesso" });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });


            }
        }

        [HttpDelete("{idAluno}")]
        public IActionResult Delete(Guid idAluno)
        {
            try 
            {
                var faculdad = _faculdadeRepository.ObterPorId(idAluno);
                if (faculdad == null)
                    return StatusCode(422, new { mensagem = "Id Invalido." });

                _faculdadeRepository.Excluir(faculdad);

                return StatusCode(201,
                    new { mensagem = $"Aluno {faculdad.Aluno}, excluido com sucesso" });

            }
            catch(Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });

            }
        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FaculdadeGetRequest>))]
        public IActionResult GetAll()
        {
            try
            {
                var faculdad = _faculdadeRepository.Consultar();
                return StatusCode(200, faculdad);
                
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });


            }
            return Ok();
        }

        [HttpGet("{idAluno}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FaculdadeGetRequest))]
        public IActionResult GetById(Guid idAluno)
        {
            try
            {
                var faculdad = _faculdadeRepository.ObterPorId(idAluno);
                return StatusCode(200, faculdad);

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });


            }
            
        }
    }
}
