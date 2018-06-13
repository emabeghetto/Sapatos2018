using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSapatos
{
    public class ModeloSapato
    {
        [Key]
        public String Modelo { get; set; }

        public bool Cadarco { get; set; }

        public string Cor { get; set; }

        public string Material { get; set; }

        public double Preco { get; set; }

        public string Foto { get; set; }


    }
}
