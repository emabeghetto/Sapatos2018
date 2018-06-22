namespace SapatosWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracao1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.Int(),
                        DataNasc = c.DateTime(),
                        CNPJ = c.String(),
                        RazaoSocial = c.String(),
                        Endereco = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tamanho = c.Int(nullable: false),
                        QtdDisponivel = c.Int(nullable: false),
                        Modelo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModeloSapatoes", t => t.Modelo_Id)
                .Index(t => t.Modelo_Id);
            
            CreateTable(
                "dbo.ModeloSapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modelo = c.String(),
                        Cadarco = c.Boolean(nullable: false),
                        Cor = c.String(),
                        Material = c.String(),
                        Preco = c.Double(nullable: false),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoteVendaSapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tamanho = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Modelo_Id = c.Int(),
                        VendaSapato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModeloSapatoes", t => t.Modelo_Id)
                .ForeignKey("dbo.VendaSapatoes", t => t.VendaSapato_Id)
                .Index(t => t.Modelo_Id)
                .Index(t => t.VendaSapato_Id);
            
            CreateTable(
                "dbo.VendaSapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        PrecoTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoteVendaSapatoes", "VendaSapato_Id", "dbo.VendaSapatoes");
            DropForeignKey("dbo.VendaSapatoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.LoteVendaSapatoes", "Modelo_Id", "dbo.ModeloSapatoes");
            DropForeignKey("dbo.Estoques", "Modelo_Id", "dbo.ModeloSapatoes");
            DropIndex("dbo.VendaSapatoes", new[] { "ClienteId" });
            DropIndex("dbo.LoteVendaSapatoes", new[] { "VendaSapato_Id" });
            DropIndex("dbo.LoteVendaSapatoes", new[] { "Modelo_Id" });
            DropIndex("dbo.Estoques", new[] { "Modelo_Id" });
            DropTable("dbo.VendaSapatoes");
            DropTable("dbo.LoteVendaSapatoes");
            DropTable("dbo.ModeloSapatoes");
            DropTable("dbo.Estoques");
            DropTable("dbo.Clientes");
        }
    }
}
