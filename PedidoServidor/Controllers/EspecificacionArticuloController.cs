using System;
using System.Collections.Generic;
using PedidoServidor.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PedidoServidor.Controllers
{
    [RoutePrefix("api/EspecificacionArticulo")]
    public class EspecificacionArticuloController : ApiController
    {
               
        // GET: api/EspecificacionArticulo/5
        [HttpGet]
        public string BuscarArticulo(string codigo)
        {
            using (var context = new BaseDeDatosContext())
            {
                var articulo = context.EspecificacionArticulo.Find(codigo);
                if (articulo == null)
                {
                    return string.Empty;
                }
                else
                {
                    return "codigo=" + articulo.Codigo + ";" +
                           "nombre=" + articulo.Nombre + ";" +
                           "descripcion=" + articulo.Descripcion;
                }
            }
        }


        // api/EspecificacionArticulo        
        [HttpGet]
        public void AgregarArticulo(string codigo, string nombre, string descripcion)
        {

            BaseDeDatosContext context = new BaseDeDatosContext();
            context.EspecificacionArticulo.Add(new Especificacion_Articulo() { Codigo = codigo, Nombre= nombre, Descripcion= descripcion});
            context.SaveChanges();
        }


        // PUT: api/EspecificacionArticulo/5
   //     public void Put(int id, [FromBody]string value)
     //   {
      //  }

        // DELETE: api/EspecificacionArticulo/5
       // public void Delete(int id)
        //{
        //}
    }
}
