using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PedidoServer.Services;

namespace PedidoServer.Controllers
{
    public class UsuariosController : ApiController
    {
        private UsuarioService _usuarioService = new UsuarioService();

        // GET: api/usuarios
        public IEnumerable<Usuario> Get() => _usuarioService.ListarUsuarios();

        [Route("api/usuarios/vendedores")]
        public IEnumerable<Vendedor> GetVendedores() => _usuarioService.ListarVendedores();

        //// GET: api/Vendedores/5
        //public Usuario Get(int id)
        //{
        //    var usu = _repositorio.UsuarioSet
        //                        .Where(usuario => usuario is Vendedor && usuario.numEmpleado == id)
        //                        .FirstOrDefault();

        //    if (usu != null)
        //    {
        //        return usu;
        //    }
        //    else
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //}



        //// PUT: api/usuarios/Vendedores
        [Route("api/usuarios/vendedores")]
        public void Put([FromBody]Vendedor vendedor)
        {
            _usuarioService.Agregar(vendedor);
        }


       

        public void Delete(int id)
        {
            _usuarioService.Remover(id);
           
        }
    }
}
