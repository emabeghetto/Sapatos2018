using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaModelos
{
    public class VendaSapato
    {
        [Key] //autoincrement de chave primaria
        public int Id { get; set; }

        [ForeignKey("ClienteVenda")]
        public int ClienteVendaID { get; set; }
        public virtual ClientePF ClienteVenda { get; set; }

        [ForeignKey("Modelo")]
        public int ModeloSapatoID { get; set; }
        public virtual ModeloSapato Modelo { get; set; }

        public int Tamanho { get; set; }
        public double Preco { get; set; }
        public virtual List<Cliente> ListaClientes { get; set; }
    }
        
}   



         






