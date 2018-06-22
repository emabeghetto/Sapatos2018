using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibliotecaModelos
{
    public class LoteVendaSapato 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement de chave primaria
        public int Id { get; set; }
        public ModeloSapato Modelo { get; set; }
        public int Tamanho { get; set; }
        public double Preco { get; set; }
        public int IdLoteVenda { get; set; }
    }
}
