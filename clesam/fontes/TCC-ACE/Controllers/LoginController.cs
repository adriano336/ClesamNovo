using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TCC_ACE;
using TCC_ACE.Models;

namespace TCC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(ModelUsuario usuario)
        {

            ModelState.AddModelError(string.Empty, "Os dados não conferem");

            if (IsValid(usuario))
            {
                Response.Redirect("~/Home");
            }


            return View(usuario);
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login");
        }

        private bool IsValid(ModelUsuario usuario)
        {


            //TODO INCLUIR USUARIO 

            bool isValid = false;
            try
            {
                using (ContextEntities db = new ContextEntities())
                {
                    var usuarioRs = db.Usuario.FirstOrDefault(u => u.login == usuario.login);

                    if (usuarioRs != null && usuarioRs.senha == usuario.senha)
                    {
                        usuario.grupo = new ModelGrupo()
                        {
                            codigo = usuarioRs.Grupo.codigo,
                            descricao = usuarioRs.Grupo.descricao
                        };

                        isValid = true;
                        FormsAuthentication.SetAuthCookie(usuario.login, false);
                        var cookie = Response.Cookies["grupo"];
                        if (cookie != null)
                        {
                            cookie["codigo"] = usuario.grupo.codigo.ToString();
                        }

                        var httpCookie = Response.Cookies["grupo"];
                        if (httpCookie != null)
                        {
                            httpCookie["nome"] = usuario.grupo.descricao;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                isValid = false;

            }

            return isValid;
        }
    }
}