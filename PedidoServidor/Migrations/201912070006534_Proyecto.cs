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
                        codigo = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        EstadoImpresion = c.Boolean(nullable: false),
                        TipoEnvio = c.String(nullable: false, maxLength: 50),
                        ClientePedido_Rut = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClientePedido_Rut, cascadeDelete: true)
                .Index(t => t.ClientePedido_Rut);
            
            CreateTable(
                "dbo.Linea_Pedido",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Articulo_codigo = c.String(nullable: false, maxLength: 128),
                        Pedido_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Especificacion_Articulo", t => t.Articulo_codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.Articulo_codigo)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        Numero = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Mail = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        Nickname = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ZonaTrabajo = c.String(nullable: false, maxLength: 200),
                        TieneVehiculo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Numero);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "ClientePedido_Rut", "dbo.Cliente");
            DropForeignKey("dbo.Linea_Pedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.Linea_Pedido", "Articulo_codigo", "dbo.Especificacion_Articulo");
            DropIndex("dbo.Linea_Pedido", new[] { "Pedido_Id" });
            DropIndex("dbo.Linea_Pedido", new[] { "Articulo_codigo" });
            DropIndex("dbo.Pedido", new[] { "ClientePedido_Rut" });
            DropTable("dbo.Vendedor");
            DropTable("dbo.Linea_Pedido");
            DropTable("dbo.Pedido");
            DropTable("dbo.Especificacion_Articulo");
            DropTable("dbo.Cliente");
        }
    }
}
