using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSapatos
{
    public class Estoque
    {
        [Key]
        public ModeloSapato Modelo { get; set; }

        public int Tamanho { get; set; }

        public int QtdDisponivel { get; set; }
    }
}
