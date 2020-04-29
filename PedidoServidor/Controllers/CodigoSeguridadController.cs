using PedidoServidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace PedidoServidor.Controllers
{
    public class CodigoSeguridadController : ApiController
    {
        // GET: api/Cliente/5
        [HttpGet]
        public String BuscarCodigo(String numCodigo)
        {
            using (var context = new BaseDeDatosContext())
            {
                var CodigoSegu = context.CodigoSeguridad.Find(numCodigo);

                if (CodigoSegu == null)
                {
                    return string.Empty;
                }
                else
                {
                    return CodigoSegu.codigo;
                }

            }


        }

    }
}
