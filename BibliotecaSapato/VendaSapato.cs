using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaSapatos
{
    public class VendaSapato
    {
        [Key]
        public int Id { get; set; }
        public Cliente ClienteVenda { get; set; }

        public List<LoteVendaSapato> LotesVenda { get; set; }

        public double PrecoTotal { get; set; }

    }
}
