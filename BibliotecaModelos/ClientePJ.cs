using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaModelos
{
    public class ClientePJ: Cliente

    {
        //Classe herdada não precisa de ID
        public String CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }



    }
}
