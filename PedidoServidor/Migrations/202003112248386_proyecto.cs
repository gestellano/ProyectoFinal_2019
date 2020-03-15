namespace PedidoServidor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proyecto : DbMigration
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
                        Codigo = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Linea_Pedido",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        CodigoArticulo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RutCliente = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        EstadoImpresion = c.Int(nullable: false),
                        Vendedor = c.String(nullable: false),
                        TipoEnvio = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropTable("dbo.Vendedor");
            DropTable("dbo.Pedido");
            DropTable("dbo.Linea_Pedido");
            DropTable("dbo.Especificacion_Articulo");
            DropTable("dbo.Cliente");
        }
    }
}
