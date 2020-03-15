using PedidoServidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PedidoServidor.Controllers
{
    [RoutePrefix("api/Pedido")]
    public class PedidoController : ApiController
    {
        // GET: api/Pedido/
       // [Route("AltaPedido")]
        [HttpGet]
        public void AltaPedido(string tipoEnvio, string rutCliente, string vendedor, int estadoImpresion,DateTime fecha)
        {
               
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Pedidos.Add(new Pedido() { RutCliente = rutCliente, Fecha = fecha, EstadoImpresion = estadoImpresion, Vendedor = vendedor, TipoEnvio = tipoEnvio });                      
            context.SaveChanges();
        }


        [HttpGet]
        public void AltaLineaPedido(string codigo, int cantidad, int idPedido)
        {
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Linea_Pedidos.Add(new Linea_Pedido() { Cantidad= cantidad, CodigoArticulo = codigo, IdPedido = idPedido});
            context.SaveChanges();
        }


        // POST: api/Pedido
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pedido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pedido/5
        public void Delete(int id)
        {
        }
    }
}
