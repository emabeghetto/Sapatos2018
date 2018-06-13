using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSapatos
{
    public class ClientePJ: Cliente

    {
        [Key]
        public String CNPJ { get; set; }

        public string RazaoSocial { get; set; }

        public string Endereco { get; set; }



    }
}
