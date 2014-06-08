using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_ACE.Menu
{
    public class Menu
    {

        public static string MenuList(Recurso recurso, int grupo)
        {
            var recursos = recurso.Recurso1.Where(s => s.Grupo.Any(g => g.codigo == grupo));
            string html = "";

            html += "<li>";
            
            html += "<a href='" + recurso.href + "' class='dropdown-toggle'>";
            if (recurso.src != null)
            {
                html += "<i class='" + recurso.src + "'></i>";
            }
            html += "<span class='menu-text'>" + recurso.titulo + "</span>";

            var enumerable = recursos as Recurso[] ?? recursos.ToArray();
            if (enumerable.Count() != 0)
            {
                html += "<b class='arrow icon-angle-down'></b>";
            }

            html += "</a>";
            if (enumerable.Count() != 0)
            {
                html += "<ul class='submenu'>";
                foreach (Recurso r in enumerable)
                {
                    html += MenuList(r, grupo);
                }
                html += "</ul>";

            }

            html += "</li>";

            return html;

        }

        public static string MenuLateral(int grupo)
        {
            ContextEntities context = new ContextEntities();
            var recursos = context.Recurso.Where(s => s.TipoRecurso.codigo == 1)
                                          .Where(s => s.Grupo.Any(g => g.codigo == grupo));

            string html = "";

            foreach (Recurso r in recursos)
            {
                html += MenuList(r, grupo);
            }

            return html;
        }

    }
}