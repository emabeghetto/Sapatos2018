using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSapatos
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

    }
}
