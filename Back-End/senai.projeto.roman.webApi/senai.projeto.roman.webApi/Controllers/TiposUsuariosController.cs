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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Um status code 200 - Ok e uma lista de tipos de usuários</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário através do id
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será buscado</param>
        /// <returns>Um status code 200 - Ok e um tipo de usuário encontrado</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo com as informações para cadastro</param>
        /// <returns>Um status code 201 - Created caso seja cadastrado ou BadRequest caso de erro</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será deletado</param>
        /// <param name="tipoAtualizado">Objeto tipoAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content caso seja atualizado ou NotFound caso não encontre</returns>
        [Authorize(Roles = "administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {
            try
            {
                if (_tipoUsuarioRepository.BuscarPorId(id) != null)
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Tipo de usuário não encontrado!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será deletado</param>
        /// <returns>Um status code 204 - No Content caso seja deletado ou BadRequest caso dê erro</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_tipoUsuarioRepository.BuscarPorId(id) != null)
                {
                    _tipoUsuarioRepository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Tipo de usuário não encontrado!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
