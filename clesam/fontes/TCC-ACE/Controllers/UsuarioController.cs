using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC_ACE.Models;
using TCC_ACE.Persistence;

namespace TCC_ACE.Controllers
{
    public class UsuarioController : Controller
    {

        public ActionResult Index() {
            IQueryable<Usuario> usuarios = new UsuarioDB(new ContextEntities()).getAll();

            Double maxPorPag = 2;
            Double count = usuarios.Count();
            Double quantidade = count / maxPorPag;
            quantidade = Math.Ceiling(quantidade);
            int quantidadePag = (int)quantidade;

            int page = 1;

            if (RouteData.Values["id"] != null)
            {
                int.TryParse(RouteData.Values["id"].ToString(), out page);
            }

            IPagedList<Usuario> usuariosret = usuarios.OrderBy(c => c.codigo).ToPagedList(page, (int)maxPorPag);
            ViewBag.usuarios = usuariosret;

            ViewBag.pagina = page;
            ViewBag.quantidadePag = quantidadePag;

            return View();
        }

        [HttpGet]
        public ActionResult Editar()
        {

            int id = 0;
            ModelUsuario usuarioModel = null;
            try
            {
                int.TryParse(RouteData.Values["id"].ToString(), out id);

                if (id == 0)
                {
                    throw new Exception("Usuário Não encontrado");
                }

                Usuario user = new UsuarioDB(new ContextEntities()).GetByCod(id);

                usuarioModel = new ModelUsuario() { codigo = user.codigo, login = user.login, titulo = user.titulo, grupo = new ModelGrupo { codigo = user.Grupo.codigo } };

                ViewData["grupos"] = listaGrupos();

            }
            catch (Exception e)
            {
                Response.Redirect("~/Usuario");
            }

            return View(usuarioModel);
        }

        [HttpPost]
        public ActionResult Editar(ModelUsuario usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    new UsuarioDB(new ContextEntities()).editarUsuario(usuarioModel);
                    ViewBag.mensagem = "Usuario salvo com sucesso.";
                }
                ViewData["grupos"] = listaGrupos();
            }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
            }

            return View(usuarioModel);
        }


        public ActionResult Incluir()
        {
            ViewData["grupos"] = listaGrupos();

            return View();
        }

        [HttpPost]
        public ActionResult Incluir(ModelUsuario usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new ContextEntities()) {
                        new UsuarioDB(context).SalvarUsuario(usuario);
                    }
                        
                    ViewBag.mensagem = "Usuario salvo com sucesso.";
                    Response.Redirect("~/Usuario");
                }


                ViewData["grupos"] = listaGrupos();
            }
            catch (Exception e)
            {
                Response.Redirect("~/Usuario");
            }


            return View(usuario);
        }


        private static List<SelectListItem> listaGrupos()
        {
            List<SelectListItem> lista = new List<SelectListItem> { new SelectListItem { Text = "Selecione um item", Value = "0" } };


            IQueryable<Grupo> grupos = new GrupoDB(new ContextEntities()).getAll();

            foreach (Grupo select in grupos)
            {
                lista.Add(new SelectListItem { Text = select.descricao, Value = select.codigo.ToString() });
            }

            return lista;
        }
	}
}