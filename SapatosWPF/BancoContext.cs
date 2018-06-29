namespace SapatosWPF
{
    using BibliotecaModelos;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class BancoContext : DbContext
    {
        // Your context has been configured to use a 'BancoContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SapatosWPF.BancoContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BancoContext' 
        // connection string in the application configuration file.
        public BancoContext()
            : base("name=BancoContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<BancoContext>());
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<ClientePF> ClientePFs { get; set; }

        public virtual DbSet<ClientePJ> ClientePJs { get; set; }

        public virtual DbSet<Estoque> Estoques { get; set; }

        public virtual DbSet<LoteVendaSapato> LoteVendaSapatos { get; set; }

        public virtual DbSet<ModeloSapato> ModeloSapatos { get; set; }

        public virtual DbSet<VendaSapato> VendaSapatos { get; set; }

        
    }


    }