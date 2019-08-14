using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace PedidoServer.Controllers
{
    public class PedidosController : ApiController
    {
        private ModeloBDContainer _repositorio = new ModeloBDContainer();
 
        // GET api/pedidos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/pedidos/5
        public Pedido Get(int id)
        {
            var transaccion = _repositorio.Database.BeginTransaction();

            var v = new Vendedor { celular = "099", email = "negro@gmail.com", nickName = "negro", nombre = "vendedor engro", numEmpleado = 1, passcode = "atun" };

            _repositorio.UsuarioSet.Add(v);

            //var v = (Vendedor)_repositorio.UsuarioSet
            //                    .Where(usuario => usuario.numEmpleado == 1)
            //                    .Single();

            //var c = _repositorio.ClienteSet.Where(cliente => cliente.Id == 1).Single();
            //var a = new Articulo { descripcion = "descripcion", imagen = "xxx" };
            //var linea = new LineaPedido { cantidad = "1" };
            //linea.Articulo.Add(a);

            //Pedido p = new Pedido
            //{
            //    fecha = System.DateTime.Now,
            //    estadoImpres = estadoImpr.pendiente,
            //    unidades = 1,
            //    envio = tipoEnvio.agencia,
            //    Vendedor = v,
            //    Cliente = c
            //};

            //p.LineaPedido.Add(linea);

            //var errores = _repositorio.GetValidationErrors().AsEnumerable().ToArray();

            //_repositorio.SaveChanges();

            //errores = _repositorio.GetValidationErrors().AsEnumerable().ToArray();

            _repositorio.Database.CurrentTransaction.Commit();
            _repositorio.SaveChanges();

            return null;
        }

        // POST api/pedidos
        public void Post([FromBody]string value)
        {

        }

        // PUT api/pedidos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/pedidos/5
        public void Delete(int id)
        {
        }
    }
}