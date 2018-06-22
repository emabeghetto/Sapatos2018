using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibliotecaModelos
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement de chave primaria
        public int Id { get; set; }

        public string Nome { get; set; }

    }
}
