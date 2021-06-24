using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.projeto.roman.webApi.Domains;
using senai.projeto.roman.webApi.Interfaces;
using senai.projeto.roman.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }

        public ProjetosController()
        {
            _projetoRepository = new ProjetoRepository();
        }

        /// <summary>
        /// Lista todos os temas
        /// </summary>
        /// <returns>Um status code 200 - Ok e uma lista de projetos</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_projetoRepository.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Lista todos os projetos de um determinado tema
        /// </summary>
        /// <param name="id">Id do tema</param>
        /// <returns>Uma lista de projetos</returns>
        [Authorize(Roles = "professor")]
        [HttpGet("tema/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_projetoRepository.ListarPorTema(id));
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Busca um projeto através do id
        /// </summary>
        /// <param name="id">Id do projeto que será buscado</param>
        /// <returns>Um status code 200 - Ok e um projeto encontrado</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_projetoRepository.BuscarPorId(id));
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Cadastra um projeto
        /// </summary>
        /// <param name="novoProjeto">Objeto novoProjeto com as informações para cadastro</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "professor")]
        [HttpPost]
        public IActionResult Post(Projeto novoProjeto)
        {
            try
            {
                if (_projetoRepository.BuscarPorNome(novoProjeto.NomeProjeto) == null)
                {
                    _projetoRepository.Cadastrar(novoProjeto);

                    return StatusCode(201);
                }

                return BadRequest("Já existe um projeto cadastrado com este nome!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Deleta um projeto existente
        /// </summary>
        /// <param name="id">Id do projeto que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_projetoRepository.BuscarPorId(id) != null)
                {
                    _projetoRepository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Projeto não encontrado");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
