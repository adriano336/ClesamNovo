using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TCC_ACE;

namespace TCC_ACE.Controllers
{
    public class PacienteController : Controller
    {
        private ContextEntities db = new ContextEntities();

        // GET: /Paciente/
        public ActionResult Index()
        {
            return View(db.Paciente.ToList());
        }

        // GET: /Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: /Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Paciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Prontuario,Nome,DataNascimento,Logradouro,NumeroLogradouro,Bairro,TelefoneResidencia,TelefoneCelular,TelefoneComercial,EstadoCivil,Escolaridade,Profissao,Sexo,Altura,Peso,Email,PacientePrecisaResponsavel,NomeResponsavel,NomeMae,NomePai,VinculoPrevidenciario,Procedencia")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Paciente.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: /Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: /Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Prontuario,Nome,DataNascimento,Logradouro,NumeroLogradouro,Bairro,TelefoneResidencia,TelefoneCelular,TelefoneComercial,EstadoCivil,Escolaridade,Profissao,Sexo,Altura,Peso,Email,PacientePrecisaResponsavel,NomeResponsavel,NomeMae,NomePai,VinculoPrevidenciario,Procedencia")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: /Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: /Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            db.Paciente.Remove(paciente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public static List<SelectListItem> PopularDropDown<E>(E enumerador) where E : class
        {
            return Enum.GetValues(typeof(E)).Cast<E>()
                .Select(vr => new SelectListItem() { Selected = false, Text = vr.ToString(), Value = (vr).ToString() }).ToList();
        }
    }
}
