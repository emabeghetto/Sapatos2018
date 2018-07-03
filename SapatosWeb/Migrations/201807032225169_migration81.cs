namespace SapatosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration81 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "VendaSapato_Id", c => c.Int());
            CreateIndex("dbo.Clientes", "VendaSapato_Id");
            AddForeignKey("dbo.Clientes", "VendaSapato_Id", "dbo.VendaSapatoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "VendaSapato_Id", "dbo.VendaSapatoes");
            DropIndex("dbo.Clientes", new[] { "VendaSapato_Id" });
            DropColumn("dbo.Clientes", "VendaSapato_Id");
        }
    }
}
