namespace BibliotecaSapato
{
    using BibliotecaSapatos;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BancoDeDadosSapato_1529302 : DbContext
    {
        // Your context has been configured to use a 'BancoDeDadosSapato_1529302' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BibliotecaSapato.BancoDeDadosSapato_1529302' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BancoDeDadosSapato_1529302' 
        // connection string in the application configuration file.
        public BancoDeDadosSapato_1529302()
            : base("name=BancoDeDadosSapato_1529302")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Cliente> Cliente_Set { get; set; }

        public virtual DbSet<ClientePF> ClientePF_Set { get; set; }

        public virtual DbSet<ClientePJ> ClientePJ_Set { get; set; }

        public virtual DbSet<Estoque> Estoque_Set { get; set; }

        public virtual DbSet<LoteVendaSapato> LoteVendaSapato_Set { get; set; }

        public virtual DbSet<ModeloSapato> ModeloSapato_Set { get; set; }

        public virtual DbSet<VendaSapato> VendaSapato_Set { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}