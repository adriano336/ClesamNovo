//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCC_ACE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recurso
    {
        public Recurso()
        {
            this.Recurso1 = new HashSet<Recurso>();
            this.Grupo = new HashSet<Grupo>();
        }
    
        public int codigo { get; set; }
        public string href { get; set; }
        public string src { get; set; }
        public string titulo { get; set; }
        public int tipoRecurso_codigo { get; set; }
        public Nullable<int> recursoPai_codigo { get; set; }
    
        public virtual ICollection<Recurso> Recurso1 { get; set; }
        public virtual Recurso Recurso2 { get; set; }
        public virtual TipoRecurso TipoRecurso { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}