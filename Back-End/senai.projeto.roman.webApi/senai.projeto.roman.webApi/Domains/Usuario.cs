using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.projeto.roman.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Professores = new HashSet<Professore>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o tipo de usuário!")]
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe a E-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha!")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha deve conter de 8 à 30 caracteres")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Professore> Professores { get; set; }
    }
}
