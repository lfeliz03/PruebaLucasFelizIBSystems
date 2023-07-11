namespace PruebaLucasFelizIBSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTablaProductosOrdenes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductosOrdenes",
                c => new
                    {
                        IdProductoOrden = c.Int(nullable: false, identity: true),
                        Orden_IdOrden = c.Int(),
                        Producto_IdProducto = c.Int(),
                    })
                .PrimaryKey(t => t.IdProductoOrden)
                .ForeignKey("dbo.Ordenes", t => t.Orden_IdOrden)
                .ForeignKey("dbo.Productos", t => t.Producto_IdProducto)
                .Index(t => t.Orden_IdOrden)
                .Index(t => t.Producto_IdProducto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductosOrdenes", "Producto_IdProducto", "dbo.Productos");
            DropForeignKey("dbo.ProductosOrdenes", "Orden_IdOrden", "dbo.Ordenes");
            DropIndex("dbo.ProductosOrdenes", new[] { "Producto_IdProducto" });
            DropIndex("dbo.ProductosOrdenes", new[] { "Orden_IdOrden" });
            DropTable("dbo.ProductosOrdenes");
        }
    }
}
