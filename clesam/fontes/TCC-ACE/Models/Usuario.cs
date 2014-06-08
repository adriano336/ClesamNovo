using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TCC_ACE;

namespace TCC_ACE.Models
{

    public class TipoRecurso
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public string ordem { get; set; }
    }

    public class Recurso
    {
        public int codigo { get; set; }
        public string href { get; set; }
        public string src { get; set; }
        public string titulo { get; set; }
        public Recurso recursoPai { get; set; }
        public TipoRecurso tipoRecurso { get; set; }
    }

    public class ModelGrupo
    {

        public int codigo { get; set; }
        [Display(Name = "Grupo")]
        public string descricao { get; set; }
        public bool ativo { get; set; }

    }

    public class ModelUsuario
    {
        public int codigo { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string senha { get; set; }
        [Display(Name = "Título")]
        public string titulo { get; set; }
        [Required]
        [Display(Name = "Login")]
        public string login { get; set; }

        public ModelGrupo grupo { get; set; }
    }
}