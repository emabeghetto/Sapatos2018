using BibliotecaModelos;
using SapatosWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SapatosWeb.Controllers
{
    public class SapatosController : Controller
    {
        ContextoBanco1 ctx = new ContextoBanco1();
        // GET: Sapatos
        public ActionResult Index()
        {
            if(TempData["msgSalvo"] != null)
            {
                Response.Write("<script>alert('Cadastro Salvo');</script>");
                TempData.Remove("msgSalvo");
            }
            ContextoBanco1 ctx = new ContextoBanco1();
            List<ModeloSapato> sapatosSalvos = ctx.Sapatos.ToList();
            return View(sapatosSalvos);
        }

        public ActionResult Create()
        {
           return View();
        }


        [HttpPost]
        public ActionResult Create(ModeloSapato sapatoNovo)
        {
            if (ModelState.IsValid)
            {
                
                ctx.Sapatos.Add(sapatoNovo);
                ctx.SaveChanges();
                TempData["msgSalvo"] = "Salvo com sucesso!";
                return RedirectToAction("Index");
            }
            

            return View();
        }

        //get
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloSapato sapatoedit = ctx.Sapatos.Find(id);
            if (sapatoedit == null)
            {
                return HttpNotFound();
            }
            ViewBag.SapatoID = new SelectList(ctx.Sapatos, "Modelo", "Cadarco", "Cor", "Material", "Preco");
            
            return View(sapatoedit);
            
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Modelo, Cadarco, Cor, Material, Preco")] ModeloSapato sapatosalvo)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(sapatosalvo).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SapatoID = new SelectList(ctx.Sapatos, "Modelo", "Cadarco", "Cor", "Material", "Preco");
            return View(sapatosalvo);
        }


        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)//com ou sem a interrogação?
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloSapato sapatodelete = ctx.Sapatos.Find(id);
            if (sapatodelete == null)
            {
                return HttpNotFound();
            }
            return View(sapatodelete);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModeloSapato sapatodeleteConfirmed = ctx.Sapatos.Find(id);
            ctx.Sapatos.Remove(sapatodeleteConfirmed);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}