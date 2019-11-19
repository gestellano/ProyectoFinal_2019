namespace PedidoServidor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Proyecto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Rut = c.String(nullable: false, maxLength: 128),
                        NombreEmp = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(maxLength: 50),
                        Ciudad = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Rut);
            
            CreateTable(
                "dbo.Especificacion_Articulo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        EstadoImpresion = c.Boolean(nullable: false),
                        TipoEnvio = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Linea_Pedido",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Articulo_Id = c.Int(nullable: false),
                        Pedido_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Especificacion_Articulo", t => t.Articulo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.Articulo_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Numero = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Mail = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        Nickname = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Numero);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        Numero = c.Int(nullable: false),
                        TieneVehiculo = c.Boolean(nullable: false),
                        ZonaTrabajo = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Numero)
                .ForeignKey("dbo.Usuario", t => t.Numero)
                .Index(t => t.Numero);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendedor", "Numero", "dbo.Usuario");
            DropForeignKey("dbo.Linea_Pedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.Linea_Pedido", "Articulo_Id", "dbo.Especificacion_Articulo");
            DropIndex("dbo.Vendedor", new[] { "Numero" });
            DropIndex("dbo.Linea_Pedido", new[] { "Pedido_Id" });
            DropIndex("dbo.Linea_Pedido", new[] { "Articulo_Id" });
            DropTable("dbo.Vendedor");
            DropTable("dbo.Usuario");
            DropTable("dbo.Linea_Pedido");
            DropTable("dbo.Pedido");
            DropTable("dbo.Especificacion_Articulo");
            DropTable("dbo.Cliente");
        }
    }
}
