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
    public class VendaSapatoesController : Controller
    {
        private ContextoBanco1 db = new ContextoBanco1();

        // GET: VendaSapatoes
        public async Task<ActionResult> Index()
        {
            var vendaSapatoes = db.VendaSapatoes.Include(v => v.ClienteVenda).Include(v => v.Modelo);
            return View(await vendaSapatoes.ToListAsync());
        }

        // GET: VendaSapatoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaSapato vendaSapato = await db.VendaSapatoes.FindAsync(id);
            if (vendaSapato == null)
            {
                return HttpNotFound();
            }
            return View(vendaSapato);
        }

        // GET: VendaSapatoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteVendaID = new SelectList(db.ClientePFs, "Id", "Nome");
            ViewBag.ModeloSapatoID = new SelectList(db.Sapatos, "Id", "Modelo");
            return View();
        }

        // POST: VendaSapatoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ClienteVendaID,ModeloSapatoID,Tamanho,Preco")] VendaSapato vendaSapato)
        {
            Estoque a = db.Estoques.Where(b => b.ModeloId.Equals(vendaSapato.ModeloSapatoID)).FirstOrDefault();
           

            if (ModelState.IsValid)
            {
                if (a == null)
                {
                    Response.Write("<script>alert('Este modelo não tem estoque cadastrado');</script>");
                }

                else if(a.QtdDisponivel <= 0)
                {
                    Response.Write("<script>alert('Acabou o estoque desse modelo');</script>");
                }

                else
                {
                    db.VendaSapatoes.Add(vendaSapato);

                    Estoque estoqueatualizado = a;
                    estoqueatualizado.QtdDisponivel --;
                    db.Entry(estoqueatualizado).State = EntityState.Modified;

                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                    
                }
                
            }

            ViewBag.ClienteVendaID = new SelectList(db.ClientePFs, "Id", "Nome", vendaSapato.ClienteVendaID);
            ViewBag.ModeloSapatoID = new SelectList(db.Sapatos, "Id", "Modelo", vendaSapato.ModeloSapatoID);
            return View(vendaSapato);
        }

        // GET: VendaSapatoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaSapato vendaSapato = await db.VendaSapatoes.FindAsync(id);
            if (vendaSapato == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteVendaID = new SelectList(db.ClientePFs, "Id", "Nome", vendaSapato.ClienteVendaID);
            ViewBag.ModeloSapatoID = new SelectList(db.Sapatos, "Id", "Modelo", vendaSapato.ModeloSapatoID);
            return View(vendaSapato);
        }

        // POST: VendaSapatoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClienteVendaID,ModeloSapatoID,Tamanho,Preco")] VendaSapato vendaSapato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendaSapato).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteVendaID = new SelectList(db.ClientePFs, "Id", "Nome", vendaSapato.ClienteVendaID);
            ViewBag.ModeloSapatoID = new SelectList(db.Sapatos, "Id", "Modelo", vendaSapato.ModeloSapatoID);
            return View(vendaSapato);
        }

        // GET: VendaSapatoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaSapato vendaSapato = await db.VendaSapatoes.FindAsync(id);
            if (vendaSapato == null)
            {
                return HttpNotFound();
            }
            return View(vendaSapato);
        }

        // POST: VendaSapatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VendaSapato vendaSapato = await db.VendaSapatoes.FindAsync(id);
            db.VendaSapatoes.Remove(vendaSapato);
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
