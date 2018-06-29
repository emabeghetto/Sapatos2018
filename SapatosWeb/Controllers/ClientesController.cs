using BibliotecaModelos;
using SapatosWeb.Models;
using SapatosWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SapatosWeb.Controllers
{
    public class ClientesController : Controller
    {

        ContextoBanco ctx = new ContextoBanco();


        // GET: Clientes
        public ActionResult Index()
        {

            if (TempData["msgSalvo"] != null)
            {
                Response.Write("<script>alert('Cadastro Salvo');</script>");
                TempData.Remove("msgSalvo");
            }

            ClientesViewModel cvm = new ClientesViewModel(ctx.ClientePFs.ToList(), ctx.ClientePJs.ToList());
            return View(cvm);


        }


        //----- PF -----

        public ActionResult ListaPF()
        {

            if (TempData["msgSalvo"] != null)
            {
                Response.Write("<script>alert('Cadastro Salvo');</script>");
                TempData.Remove("msgSalvo");
            }

            List<ClientePF> clientePFlista = ctx.ClientePFs.ToList();
            return View(clientePFlista);

        }


        

        public ActionResult CreatePF()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePF(ClientePF clientePFnovo)
        {
            if (ModelState.IsValid)
            {

                ctx.ClientePFs.Add(clientePFnovo);
                ctx.SaveChanges();
                TempData["msgSalvo"] = "Salvo com sucesso!";
                return RedirectToAction("Index");
            }


            return View();
        }

        //get
        public ActionResult EditPF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientePF clientePFedit = ctx.ClientePFs.Find(id);
            if (clientePFedit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientePFId = new SelectList(ctx.ClientePFs, "Nome", "CPF", "DataNasc");

            return View(clientePFedit);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPF([Bind(Include = "Id, Nome, CPF, DataNasc")] ClientePF clientePFsalvo)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(clientePFsalvo).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientePFId = new SelectList(ctx.ClientePFs, "Nome", "CPF", "DataNasc");

            return View(clientePFsalvo);
        }







        //----- PJ -----

        public ActionResult CreatePJ()
        {
            return View();
        }

        public ActionResult ListaPJ()
        {

            if (TempData["msgSalvo"] != null)
            {
                Response.Write("<script>alert('Cadastro Salvo');</script>");
                TempData.Remove("msgSalvo");
            }

            List<ClientePJ> clientePJlista = ctx.ClientePJs.ToList();
            return View(clientePJlista);

        }


        [HttpPost]
        public ActionResult CreatePJ(ClientePJ clientePJnovo)
        {
            if (ModelState.IsValid)
            {

                ctx.ClientePJs.Add(clientePJnovo);
                ctx.SaveChanges();
                TempData["msgSalvo"] = "Salvo com sucesso!";
                return RedirectToAction("Index");
            }


            return View();
        }

        //get
        public ActionResult EditPJ(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientePJ clientePJedit = ctx.ClientePJs.Find(id);
            if (clientePJedit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteIdPJ = new SelectList(ctx.ClientePJs, "Id", "Nome", "CNPJ", "RazaoSocial","Endereco");

            return View(clientePJedit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPJ([Bind(Include = "Id, Nome, , CNPJ, Endereco")] ClientePJ clientePJsalvo)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(clientePJsalvo).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientePJId = new SelectList(ctx.ClientePJs, "Id", "Nome", "RazaoSocial", "CNPJ", "Endereco");

            return View(clientePJsalvo);
        }




    }
}