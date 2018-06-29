using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SapatosWeb.ViewModels
{
    public class ClientesViewModel
    {
        public List<ClientePF> ClientesPF { get; set; }

        public List<ClientePJ> ClientesPJ { get; set; }

        public ClientesViewModel(List<ClientePF> pfs, List<ClientePJ> pjs)
        {
            this.ClientesPF = pfs;
            this.ClientesPJ = pjs;
        }
    }
}