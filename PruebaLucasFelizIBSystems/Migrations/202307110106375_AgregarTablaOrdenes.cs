namespace PruebaLucasFelizIBSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTablaOrdenes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ordenes",
                c => new
                    {
                        IdOrden = c.Int(nullable: false, identity: true),
                        FechaHoraOrden = c.DateTime(nullable: false),
                        EstatusOrden = c.Int(nullable: false),
                        Cliente_IdCliente = c.Int(),
                    })
                .PrimaryKey(t => t.IdOrden)
                .ForeignKey("dbo.Clientes", t => t.Cliente_IdCliente)
                .Index(t => t.Cliente_IdCliente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ordenes", "Cliente_IdCliente", "dbo.Clientes");
            DropIndex("dbo.Ordenes", new[] { "Cliente_IdCliente" });
            DropTable("dbo.Ordenes");
        }
    }
}
