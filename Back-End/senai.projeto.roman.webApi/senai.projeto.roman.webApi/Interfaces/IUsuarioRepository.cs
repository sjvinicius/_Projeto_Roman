using senai.projeto.roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um usuário através do id
        /// </summary>
        /// <param name="id">id do usuário buscado</param>
        /// <returns>Um usuário encontrado ou null</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Busca um usuário pelo email
        /// </summary>
        /// <param name="email">E-mail do usuário que será buscado</param>
        /// <returns>Um usuário encontrado ou null</returns>
        Usuario BuscarPorEmail(string email);

        /// <summary>
        /// Efetua o login do usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um usuário encontrado ou null</returns>
        Usuario Logar(string email, string senha);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com as informações para cadastro</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um usuário através do id
        /// </summary>
        /// <param name="id">id do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">id do usuário que será deletado</param>
        void Deletar(int id);
    }
}
