namespace PruebaLucasFelizIBSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Single(nullable: false),
                        Imagen = c.Binary(storeType: "image"),
                        Inactivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productos");
        }
    }
}
