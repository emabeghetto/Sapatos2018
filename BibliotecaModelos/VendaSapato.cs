using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaModelos
{
    public class VendaSapato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement de chave primaria
        public int Id { get; set; }
        public Cliente ClienteVenda { get; set; }
        public ModeloSapato Modelo { get; set; }
        public int Tamanho { get; set; }
        public double Preco { get; set; }
        public virtual List<Cliente> ListaClientes { get; set; }
    }
        
}   



         






