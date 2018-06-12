using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSapatos
{
    public class LoteVendaSapato 
    {
        [Key]
        public ModeloSapato Modelo { get; set; }

        public int Tamanho { get; set; }

        public double Preco { get; set; }
    }
}
