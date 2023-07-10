namespace PruebaLucasFelizIBSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTablaClientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Correo = c.String(),
                        Inactivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
