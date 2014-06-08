using System;
using System.Linq;

namespace TCC_ACE.BaseLayout
{
    public class VerificacaoRecurso
    {
        public static Boolean VerificarRecursoPermitido(int grupo, int recurso)
        {
            using (var ctx = new ContextEntities())
            {
                return ctx.Recurso.Count(r => r.Grupo.Any(g => g.codigo == grupo) && r.codigo == recurso) > 0;
            }
        }
    }
}