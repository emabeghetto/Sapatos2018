using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibliotecaModelos
{
    public class ModeloSapato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement de chave primaria
        public int Id { get; set; }
        public string Modelo { get; set; }
        public bool Cadarco { get; set; }
        public string Cor { get; set; }
        public string Material { get; set; }
        public double Preco { get; set; }
      }
}
