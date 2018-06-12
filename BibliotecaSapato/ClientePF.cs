using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSapatos
{
   public class ClientePF : Cliente
    {
        [Key]
        public int CPF { get; set; }
        public DateTime DataNasc { get; set; }

    }
}
