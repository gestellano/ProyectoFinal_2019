using PedidoServidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PedidoServidor.Controllers
{
    public class BaseController : ApiController
    {
        // GET api/<controller>
        public List<Usuario> Get()
        {
            BaseDeDatosContext baseDatos=new BaseDeDatosContext();
            return (from cliente in baseDatos.Usuarios
                   select cliente).ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(int rut,string nombre,string direccion,string ciudad,string telefono)
        {
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Clientes.Add(new Cliente() { Rut = rut, NombreEmp = nombre, Direccion = direccion, Ciudad = ciudad, Telefono = telefono });
            context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}