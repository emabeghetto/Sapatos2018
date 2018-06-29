using BibliotecaModelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SapatosWeb.Models
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco() : base("name=ContextoBanco")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ContextoBanco>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoBanco>());
        }


        public DbSet<ModeloSapato> Sapatos { get; set; }
        public DbSet<ClientePF> ClientePFs { get; set; }
        public DbSet<ClientePJ> ClientePJs { get; set; }

        public DbSet<VendaSapato> VendaSapatoes { get; set; }
    }

}
