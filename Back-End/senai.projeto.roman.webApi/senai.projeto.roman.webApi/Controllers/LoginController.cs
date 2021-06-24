using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.projeto.roman.webApi.Domains;
using senai.projeto.roman.webApi.Interfaces;
using senai.projeto.roman.webApi.Repositories;
using senai.projeto.roman.webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Efetua o login no sistema
        /// </summary>
        /// <param name="login">Objeto login com as credenciais de login</param>
        /// <returns>Um status code 200 - Ok e um token</returns>
        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Logar(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos");
                }

                var Claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    new Claim("role", usuarioBuscado.IdTipoUsuarioNavigation.NomeTipoUsuario.ToLower())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("-user_acess-roman"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Roman.webApi",
                    audience: "Roman.webApi",
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds,
                    claims: Claims
                );

                return Ok(new 
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

    }
}
