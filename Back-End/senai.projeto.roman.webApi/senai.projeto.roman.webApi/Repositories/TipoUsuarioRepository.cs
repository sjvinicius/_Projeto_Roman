using senai.projeto.roman.webApi.Contexts;
using senai.projeto.roman.webApi.Domains;
using senai.projeto.roman.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Atualiza um tipo de usuário através do id
        /// </summary>
        /// <param name="id">id do tipo de usuário que será deletado</param>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com as novas informações</param>
        public void Atualizar(int id, TiposUsuario novoTipoUsuario)
        {
            TiposUsuario tipoUsuarioBuscado = BuscarPorId(id);

            if (novoTipoUsuario.NomeTipoUsuario != null)
            {
                tipoUsuarioBuscado.NomeTipoUsuario = novoTipoUsuario.NomeTipoUsuario;
            }

            ctx.TiposUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de usuário através do id
        /// </summary>
        /// <param name="id">id do tipo de usuário buscado</param>
        /// <returns>Um tipo de usuário encontrado</returns>
        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo com as informações para cadastro</param>
        public void Cadastrar(TiposUsuario novoTipo)
        {
            ctx.TiposUsuarios.Add(novoTipo);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">id do tipo de usuário que será deletado</param>
        public void Deletar(int id)
        {
            ctx.TiposUsuarios.Remove( BuscarPorId(id) );

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }   
    }
}
