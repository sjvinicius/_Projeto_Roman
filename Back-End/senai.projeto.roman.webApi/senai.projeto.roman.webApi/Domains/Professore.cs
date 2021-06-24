using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.projeto.roman.webApi.Domains
{
    public partial class Professore
    {
        public int IdProfessor { get; set; }

        [Required(ErrorMessage = "Informe o usuário")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o nome do professor!")]
        public string NomeProfessor { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
