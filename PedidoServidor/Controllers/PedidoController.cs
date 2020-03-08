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
        [Route("AltaPedido")]
        [HttpPost]
        public void AltaPedido(string tipoEnvio, string rutCliente, string codigoProducto, string estadoImpresion,string fecha)
        {            
            bool estadoImp = false;            
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Pedidos.Add(new Pedido() { RutCliente = rutCliente, Fecha = fecha, EstadoImpresion = estadoImp,CodigoProducto = codigoProducto, TipoEnvio = tipoEnvio }); 
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
