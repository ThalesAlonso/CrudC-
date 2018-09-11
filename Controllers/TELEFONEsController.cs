using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudRiosoft.Models;

namespace CrudRiosoft.Controllers
{
    public class TELEFONEsController : Controller
    {
        private CLIENTEDBEntities db = new CLIENTEDBEntities();

        // GET: TELEFONEs
        public ActionResult Index()
        {
            var tELEFONE = db.TELEFONE.Include(t => t.CLIENTE);
            return View(tELEFONE.ToList());
        }

        // GET: TELEFONEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELEFONE tELEFONE = db.TELEFONE.Find(id);
            if (tELEFONE == null)
            {
                return HttpNotFound();
            }
            return View(tELEFONE);
        }

        // GET: TELEFONEs/Create
        public ActionResult Create()
        {
            ViewBag.CLI_COD = new SelectList(db.CLIENTE, "CLI_COD", "NOME");
            return View();
        }

        // POST: TELEFONEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLI_COD,DDD,NUMERO")] TELEFONE tELEFONE)
        {
            if (ModelState.IsValid)
            {
                db.TELEFONE.Add(tELEFONE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLI_COD = new SelectList(db.CLIENTE, "CLI_COD", "NOME", tELEFONE.CLI_COD);
            return View(tELEFONE);
        }

        // GET: TELEFONEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELEFONE tELEFONE = db.TELEFONE.Find(id);
            if (tELEFONE == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLI_COD = new SelectList(db.CLIENTE, "CLI_COD", "NOME", tELEFONE.CLI_COD);
            return View(tELEFONE);
        }

        // POST: TELEFONEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLI_COD,DDD,NUMERO")] TELEFONE tELEFONE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tELEFONE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLI_COD = new SelectList(db.CLIENTE, "CLI_COD", "NOME", tELEFONE.CLI_COD);
            return View(tELEFONE);
        }

        // GET: TELEFONEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELEFONE tELEFONE = db.TELEFONE.Find(id);
            if (tELEFONE == null)
            {
                return HttpNotFound();
            }
            return View(tELEFONE);
        }

        // POST: TELEFONEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TELEFONE tELEFONE = db.TELEFONE.Find(id);
            db.TELEFONE.Remove(tELEFONE);
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
    }
}
