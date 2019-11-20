using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PedidoServidor.Models
{
    public class BaseDeDatosContext : DbContext
    {
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Especificacion_Articulo> EspecificacionArticulo { get; set; }
       
        public BaseDeDatosContext():base("conexion")
        {

        }
    }
}