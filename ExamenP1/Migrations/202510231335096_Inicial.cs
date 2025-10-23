namespace ExamenP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ataques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreAtaque = c.String(),
                        TipoAtaque = c.String(),
                        PoderBase = c.String(),
                        DigimonId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Digimons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Nivel = c.String(),
                        Tipo = c.String(),
                        Elemento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Digimons");
            DropTable("dbo.Ataques");
        }
    }
}
