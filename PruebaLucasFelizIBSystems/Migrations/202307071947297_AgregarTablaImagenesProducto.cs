namespace PruebaLucasFelizIBSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTablaImagenesProducto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImagenesProductoes",
                c => new
                    {
                        IdImagenProducto = c.Int(nullable: false, identity: true),
                        Imagen = c.Binary(storeType: "image"),
                        Producto_IdProducto = c.Int(),
                    })
                .PrimaryKey(t => t.IdImagenProducto)
                .ForeignKey("dbo.Productos", t => t.Producto_IdProducto)
                .Index(t => t.Producto_IdProducto);
            
            DropColumn("dbo.Productos", "Imagen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "Imagen", c => c.Binary(storeType: "image"));
            DropForeignKey("dbo.ImagenesProductoes", "Producto_IdProducto", "dbo.Productos");
            DropIndex("dbo.ImagenesProductoes", new[] { "Producto_IdProducto" });
            DropTable("dbo.ImagenesProductoes");
        }
    }
}
