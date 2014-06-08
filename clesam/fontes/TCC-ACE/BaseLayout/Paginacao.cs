using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_ACE.BaseLayout
{
    public class Paginacao
    {

        public static string getPaginacao(int paginaAtual, int quantidadePaginas, string url)
        {
            string html = "";

            for (int i = 0; i <= quantidadePaginas + 1; i++)
            {
                string newurl = url + i;
                string classe = "";
                if (i == 0)
                {
                    newurl = url + (paginaAtual - 1);

                    if (1 == paginaAtual)
                    {
                        newurl = "javascript:void()";
                        classe = "disabled";
                    }

                    html += "<li class='" + classe + "'><a href='" + newurl + "'>&laquo;</a></li>";
                }
                else if (i == quantidadePaginas + 1)
                {
                    newurl = url + (paginaAtual + 1);

                    if (paginaAtual == quantidadePaginas)
                    {
                        newurl = "javascript:void()";
                        classe = "disabled";
                    }

                    html += "<li class='" + classe + "' ><a href='" + newurl + "'>&raquo;</a></li>";
                }
                else
                {

                    if (i == paginaAtual)
                    {
                        classe = "active";
                        newurl = "javascript:void()";
                    }

                    html += "<li class='" + classe + "'><a href='" + newurl + "'>" + i + "</a></li>";
                }
            }

            return html;
        }
    }
}