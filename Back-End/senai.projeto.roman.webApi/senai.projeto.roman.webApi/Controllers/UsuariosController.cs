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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Um status code 200 - Ok e uma lista de usuários</returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Busca um usuário atrávés do id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Um status code 200 - Ok e um usuário encontrado</returns>
        [Authorize(Roles = "administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as informações para cadastro</param>
        /// <returns>Um status code 201 - Created caso seja cadastrado com sucesso</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                if (_usuarioRepository.BuscarPorEmail(novoUsuario.Email) == null)
                {
                    _usuarioRepository.Cadastrar(novoUsuario);

                    return StatusCode(201);
                }

                return BadRequest("Já existe um usuário cadastrado com este E-mail!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">Id do usuário que será deletado</param>
        /// <returns>Um status code 204 - No Content caso seja deletado com sucesso</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_usuarioRepository.BuscarPorId(id) != null)
                {
                    _usuarioRepository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Usuário não encontrado!");
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
