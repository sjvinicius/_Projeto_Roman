using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.projeto.roman.webApi.Domains
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }

        [Required(ErrorMessage = "Informe o tema do projeto!")]
        public int? IdTema { get; set; }

        [Required(ErrorMessage = "Informe o nome do projeto!")]
        public string NomeProjeto { get; set; }

        [Required(ErrorMessage = "Informe a descrição do projeto!")]
        public string Descricao { get; set; }

        public virtual Tema IdTemaNavigation { get; set; }
    }
}
