namespace SapatosWeb.Models
{
    using BibliotecaModelos;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContextoBanco1 : DbContext
    {
        // Your context has been configured to use a 'ContextoBanco1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SapatosWeb.Models.ContextoBanco1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ContextoBanco1' 
        // connection string in the application configuration file.
        public ContextoBanco1() : base("name=ContextoBanco1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }


        public DbSet<ModeloSapato> Sapatos { get; set; }
        public DbSet<ClientePF> ClientePFs { get; set; }
        public DbSet<ClientePJ> ClientePJs { get; set; }
        public DbSet<VendaSapato> VendaSapatoes { get; set; }
         
    }

    

   
}