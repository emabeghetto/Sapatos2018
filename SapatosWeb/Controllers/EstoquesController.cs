using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibliotecaModelos;
using SapatosWeb.Models;

namespace SapatosWeb.Controllers
{
    public class EstoquesController : Controller
    {
        private ContextoBanco1 db = new ContextoBanco1();

        // GET: Estoques
        public async Task<ActionResult> Index()
        {
            var estoques = db.Estoques.Include(e => e.Modelo);
            return View(await estoques.ToListAsync());
        }

        // GET: Estoques/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = await db.Estoques.FindAsync(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // GET: Estoques/Create
        public ActionResult Create()
        {
            ViewBag.ModeloId = new SelectList(db.Sapatos, "Id", "Modelo");
            return View();
        }
        
        // POST: Estoques/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ModeloId,QtdDisponivel")] Estoque estoque)
        {

            List<Estoque> lstestoques = db.Estoques.ToList();
            if (ModelState.IsValid)
            {
                var a = db.Estoques.Where(b => b.ModeloId.Equals(estoque.ModeloId)).FirstOrDefault();
                if(a == null)
                {
                    db.Estoques.Add(estoque);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    Response.Write("<script>alert('Este modelo já possui cadastro');</script>");
                }
                
            }

            ViewBag.ModeloId = new SelectList(db.Sapatos, "Id", "Modelo", estoque.ModeloId);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = await db.Estoques.FindAsync(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModeloId = new SelectList(db.Sapatos, "Id", "Modelo", estoque.ModeloId);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ModeloId,QtdDisponivel")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoque).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ModeloId = new SelectList(db.Sapatos, "Id", "Modelo", estoque.ModeloId);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = await db.Estoques.FindAsync(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Estoque estoque = await db.Estoques.FindAsync(id);
            db.Estoques.Remove(estoque);
            await db.SaveChangesAsync();
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
