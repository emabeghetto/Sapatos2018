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
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        //O código esá caindo nessa excessão, nao consegui progredir sobre o erro, pois a unica recomendação que tinha é 
        //fazer o código do banco como se fosse dabasefirst, mas uma das restrições do projeto e que fosse modelfirst
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
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