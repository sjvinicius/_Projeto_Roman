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
    public class TemasController : ControllerBase
    {
        private ITemaRepository _temaRepository { get; set; }

        public TemasController()
        {
            _temaRepository = new TemaRepository();
        }

        /// <summary>
        /// Lista todos os temas
        /// </summary>
        /// <returns>Uma status code 200 - Ok e uma lista de temas</returns>
        [Authorize(Roles = "administrador, professor")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_temaRepository.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Busca um tema através do id
        /// </summary>
        /// <param name="id">Id do tema que será buscado</param>
        /// <returns>Um status code 200 - Ok e o tema buscado</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_temaRepository.BuscarPorId(id));
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Cadastra um tema
        /// </summary>
        /// <param name="novoTema">Objeto novoTema com as informações para cadastro</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "professor, administrador")]
        [HttpPost]
        public IActionResult Post(Tema novoTema)
        {
            try
            {
                _temaRepository.Cadastrar(novoTema);

                return StatusCode(201);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Atualiza um tema existente através de seu id
        /// </summary>
        /// <param name="id">Id do tema que será atualizado</param>
        /// <param name="temaAtualizado">Objeto tema atualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content caso seja atualizado ou NotFound caso não encontre o tema</returns>
        [Authorize(Roles = "professor, administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Tema temaAtualizado)
        {
            try
            {
                if (_temaRepository.BuscarPorId(id) != null)
                {
                    _temaRepository.Atualizar(id, temaAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Tema não encontrado!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Deleta um tema existente
        /// </summary>
        /// <param name="id">Id do tema que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_temaRepository.BuscarPorId(id) != null)
                {
                    _temaRepository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Tema não encontrado!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
