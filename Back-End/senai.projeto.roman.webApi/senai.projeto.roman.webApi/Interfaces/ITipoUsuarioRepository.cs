using senai.projeto.roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do id
        /// </summary>
        /// <param name="id">id do tipo de usuário buscado</param>
        /// <returns>Um tipo de usuário encontrado</returns>
        TiposUsuario BuscarPorId(int id);
        
        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Objeto novoTipo com as informações para cadastro</param>
        void Cadastrar(TiposUsuario novoTipo);

        /// <summary>
        /// Atualiza um tipo de usuário através do id
        /// </summary>
        /// <param name="id">id do tipo de usuário que será atualizado</param>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com as novas informações</param>
        void Atualizar(int id, TiposUsuario novoTipoUsuario);

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">id do tipo de usuário que será deletado</param>
        void Deletar(int id);
    }
}
