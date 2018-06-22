using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaModelos
{
    public class VendaSapato
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement de chave primaria
        public int Id { get; set; }

        public int ClienteId { get; set; }
        
        [ForeignKey("ClienteId")] //referencia a chave estrangeira pra não precisar fazer uma cadeia de consultas no bd
        public Cliente ClienteVenda { get; set; }

        
        public ICollection<LoteVendaSapato> LotesVenda { get; set; }
        [InverseProperty("LotesVenda")] //atribui automaticamente o sapato da venda ao lote

        public double PrecoTotal { get; set; }

    }
}
