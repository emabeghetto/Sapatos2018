using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibliotecaModelos;
using SapatosWeb.Models;
using SapatosWeb.ViewModels;

namespace SapatosWeb.Controllers
{
    public class VendasController : Controller
    {

         

        private ContextoBanco1 db = new ContextoBanco1();

       


        // GET: Vendas
        public ActionResult Index()
        {
            return View(db.VendaSapatoes.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaSapato vendaSapato = db.VendaSapatoes.Find(id);
            if (vendaSapato == null)
            {
                return HttpNotFound();
            }
            return View(vendaSapato);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cliente,Modelo,Tamanho,Preco")] VendaSapato vendaSapato)
        {
            if (ModelState.IsValid)
            {
                db.VendaSapatoes.Add(vendaSapato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendaSapato);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaSapato vendaSapato = db.VendaSapatoes.Find(id);
            if (vendaSapato == null)
            {
                return HttpNotFound();
            }
            return View(vendaSapato);
        }

        // POST: Vendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cliente,Modelo,Tamanho,Preco")] VendaSapato vendaSapato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendaSapato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendaSapato);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaSapato vendaSapato = db.VendaSapatoes.Find(id);
            if (vendaSapato == null)
            {
                return HttpNotFound();
            }
            return View(vendaSapato);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendaSapato vendaSapato = db.VendaSapatoes.Find(id);
            db.VendaSapatoes.Remove(vendaSapato);
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
