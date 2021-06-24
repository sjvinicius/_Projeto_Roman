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
    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Atualiza um projeto existente
        /// </summary>
        /// <param name="id">Id do projeto que será atualizado</param>
        /// <param name="projetoAtualizado">Objeto projetoAtualizado com as novas informações</param>
        public void Atualizar(int id, Projeto projetoAtualizado)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Busca um projeto através do seu id
        /// </summary>
        /// <param name="id">Id do projeto que será buscado</param>
        /// <returns>Um projeto encontrado ou null</returns>
        public Projeto BuscarPorId(int id)
        {
            return ctx.Projetos.Include(p => p.IdTemaNavigation).FirstOrDefault(p => p.IdProjeto == id);
        }

        /// <summary>
        /// Busca um projeto pelo nome
        /// </summary>
        /// <param name="nomeProjeto">nome do projeto que será buscado</param>
        /// <returns>Um projeto encontrado ou null</returns>
        public Projeto BuscarPorNome(string nomeProjeto)
        {
            return ctx.Projetos.FirstOrDefault(p => p.NomeProjeto == nomeProjeto);
        }

        /// <summary>
        /// Cadastra um projeto
        /// </summary>
        /// <param name="novoProjeto">Objeto novProjeto com as informações para cadastro</param>
        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um projeto existente
        /// </summary>
        /// <param name="id">Id do projeto que será deletado</param>
        public void Deletar(int id)
        {
            ctx.Projetos.Remove(ctx.Projetos.FirstOrDefault(p => p.IdProjeto == id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os projetos
        /// </summary>
        /// <returns>Uma lista de projetos</returns>
        public List<Projeto> Listar()
        {
            return ctx.Projetos
                .Include(p => p.IdTemaNavigation)
                .Select(p => new Projeto 
                { 
                    IdProjeto = p.IdProjeto,
                    NomeProjeto = p.NomeProjeto,
                    Descricao = p.Descricao,
                    IdTema = p.IdTema,
                    IdTemaNavigation = p.IdTemaNavigation
                })
                .ToList();
        }

        /// <summary>
        /// Lista todos os projetos de um determinado tema
        /// </summary>
        /// <param name="idTema">Id do tema</param>
        /// <returns>Uma lista de projetos</returns>
        public List<Projeto> ListarPorTema(int idTema)
        {
            return ctx.Projetos
                .Include(p => p.IdTemaNavigation)
                .Select(p => new Projeto
                {
                    IdProjeto = p.IdProjeto,
                    NomeProjeto = p.NomeProjeto,
                    Descricao = p.Descricao,
                    IdTema = p.IdTema,
                    IdTemaNavigation = p.IdTemaNavigation
                })
                .Where(p => p.IdTema == idTema)
                .ToList();
        }
    }
}
