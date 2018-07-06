using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibliotecaModelos
{
    public class Estoque
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement de chave primaria
        public int Id { get; set; }

        [ForeignKey("Modelo")]
        public  int ModeloId { get; set; }
        public virtual ModeloSapato Modelo { get; set; }
        
        public int QtdDisponivel { get; set; }
    }
}
