using senai.projeto.roman.webApi.Contexts;
using senai.projeto.roman.webApi.Domains;
using senai.projeto.roman.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.projeto.roman.webApi.Repositories
{
    public class TemaRepository : ITemaRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Atualiza um tema existente
        /// </summary>
        /// <param name="id">Id do tema que será atualizado</param>
        /// <param name="temaAtualizado">Objeto temaAtualizado com as novas informações</param>
        public void Atualizar(int id, Tema temaAtualizado)
        {
            Tema temaBuscado = BuscarPorId(id);

            if (temaAtualizado.NomeTema != null)
            {
                temaBuscado.NomeTema = temaAtualizado.NomeTema;
            }

            ctx.Temas.Update(temaBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tema pelo id
        /// </summary>
        /// <param name="id">Id do tema buscado</param>
        /// <returns>Um tema encontrado ou null</returns>
        public Tema BuscarPorId(int id)
        {
            return ctx.Temas.FirstOrDefault(t => t.IdTema == id);
        }

        /// <summary>
        /// Cadastra um novo tema
        /// </summary>
        /// <param name="novoTema">Objeto novoTema com as informações para cadastro</param>
        public void Cadastrar(Tema novoTema)
        {
            ctx.Temas.Add(novoTema);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tema existente
        /// </summary>
        /// <param name="id">Id do tema que será deletado</param>
        public void Deletar(int id)
        {
            ctx.Temas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os temas
        /// </summary>
        /// <returns>Uma lista de temas</returns>
        public List<Tema> Listar()
        {
            return ctx.Temas.ToList();
        }
    }
}
