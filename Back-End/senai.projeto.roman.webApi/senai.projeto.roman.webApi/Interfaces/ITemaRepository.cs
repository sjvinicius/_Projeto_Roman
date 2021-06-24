using senai.projeto.roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Interfaces
{
    interface ITemaRepository
    {
        /// <summary>
        /// Lista todos os temas
        /// </summary>
        /// <returns>Uma lista de temas</returns>
        List<Tema> Listar();

        /// <summary>
        /// Busca um tema pelo id
        /// </summary>
        /// <param name="id">Id do tema buscado</param>
        /// <returns>Um tema encontrado ou null</returns>
        Tema BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tema
        /// </summary>
        /// <param name="novoTema">Objeto novoTema com as informações para cadastro</param>
        void Cadastrar(Tema novoTema);

        /// <summary>
        /// Atualiza um tema existente
        /// </summary>
        /// <param name="id">Id do tema que será atualizado</param>
        /// <param name="temaAtualizado">Objeto temaAtualizado com as novas informações</param>
        void Atualizar(int id, Tema temaAtualizado);

        /// <summary>
        /// Deleta um tema existente
        /// </summary>
        /// <param name="id">Id do tema que será deletado</param>
        void Deletar(int id);
    }
}
