using senai.projeto.roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Interfaces
{
    interface IProjetoRepository
    {
        /// <summary>
        /// Lista todos os projetos
        /// </summary>
        /// <returns>Uma lista de projetos</returns>
        List<Projeto> Listar();

        /// <summary>
        /// Lista todos os projetos de um determinado tema
        /// </summary>
        /// <param name="idTema">Id do tema</param>
        /// <returns>Uma lista de projetos</returns>
        List<Projeto> ListarPorTema(int idTema);

        /// <summary>
        /// Busca um projeto pelo nome
        /// </summary>
        /// <param name="nomeProjeto">nome do projeto que será buscado</param>
        /// <returns>Um projeto encontrado ou null</returns>
        Projeto BuscarPorNome(string nomeProjeto);

        /// <summary>
        /// Busca um projeto através do seu id
        /// </summary>
        /// <param name="id">Id do projeto que será buscado</param>
        /// <returns>Um projeto encontrado ou null</returns>
        Projeto BuscarPorId(int id);

        /// <summary>
        /// Cadastra um projeto
        /// </summary>
        /// <param name="novoProjeto">Objeto novProjeto com as informações para cadastro</param>
        void Cadastrar(Projeto novoProjeto);

        /// <summary>
        /// Atualiza um projeto existente
        /// </summary>
        /// <param name="id">Id do projeto que será atualizado</param>
        /// <param name="projetoAtualizado">Objeto projetoAtualizado com as novas informações</param>
        void Atualizar(int id, Projeto projetoAtualizado);

        /// <summary>
        /// Deleta um projeto existente
        /// </summary>
        /// <param name="id">Id do projeto que será deletado</param>
        void Deletar(int id);
    }
}
