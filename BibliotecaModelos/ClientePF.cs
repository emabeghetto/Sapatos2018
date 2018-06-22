using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibliotecaModelos
{
   public class ClientePF : Cliente
    {
        //Classe herdada não precisa de ID 
        public int CPF { get; set; }
        public DateTime DataNasc { get; set; }

    }
}
