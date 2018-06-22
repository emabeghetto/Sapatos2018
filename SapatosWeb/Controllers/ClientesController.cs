using BibliotecaModelos;
using SapatosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SapatosWeb.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            ContextoBanco ctx = new ContextoBanco();

            if (TempData["msgSalvo"] != null)
            {
                Response.Write("<script>alert('Cadastro Salvo');</script>");
                TempData.Remove("msgSalvo");
            }
            
            List<Cliente> Clientes = ctx.Clientes.ToList();
            return View(Clientes);
            
        }
    }
}