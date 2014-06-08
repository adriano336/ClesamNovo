using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_ACE.Persistence
{
    public class GrupoDB
    {
            private ContextEntities context { get; set; }

            public GrupoDB(ContextEntities context)
            {
                this.context = context;
            }

            public IQueryable<Grupo> getAll() {

                IQueryable<Grupo> grupos = from grupo in context.Grupo
                                           select grupo;

                return grupos;
            }

    }
}