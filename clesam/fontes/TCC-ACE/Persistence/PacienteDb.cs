using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCC_ACE.Models;

namespace TCC_ACE.Persistence
{
    public class PacienteDb
    {
        private ContextEntities Context { get; set; }

        public PacienteDb(ContextEntities context)
        {
            this.Context = context;
        }
    }
}