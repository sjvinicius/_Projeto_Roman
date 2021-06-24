using Microsoft.EntityFrameworkCore;
using senai.projeto.roman.webApi.Contexts;
using senai.projeto.roman.webApi.Domains;
using senai.projeto.roman.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoUsuarioNavigation)
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    IdTipoUsuario = u.IdTipoUsuario,
                    Email = u.Email,
                    Senha = u.Senha,
                    IdTipoUsuarioNavigation = u.IdTipoUsuarioNavigation
                }).FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as informações para cadastro</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<Usuario> Listar()
        {
            return ctx.Usuarios
                .Include(u => u.IdTipoUsuarioNavigation)
                .Select(u => new Usuario 
                { 
                    IdUsuario       = u.IdUsuario,
                    IdTipoUsuario   = u.IdTipoUsuario,
                    Email           = u.Email,
                    Senha           = u.Senha,
                    IdTipoUsuarioNavigation = u.IdTipoUsuarioNavigation
                }).ToList();
        }

        /// <summary>
        /// Efetua o login do usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um usuário encontrado ou null</returns>
        public Usuario Logar(string email, string senha)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

    }
}
