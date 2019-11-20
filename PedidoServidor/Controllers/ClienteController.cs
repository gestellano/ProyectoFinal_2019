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
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
         public List<Cliente> Get()
         {
             BaseDeDatosContext baseDatos = new BaseDeDatosContext();
             return (from cliente in baseDatos.Clientes
                     select cliente).ToList();
         }
/*
        public string Buscar(string rut)
        {
            Cliente cliente = (from c in context.Clientes where c.Rut == rut select c).FirstOrDefault();
            return JsonConvert.SerializeObject(cliente);
        }

*/
        // GET: api/Cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        public void Post(string rut, string nombre, string direccion, string ciudad, string telefono)
        {
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Clientes.Add(new Cliente() { Rut = rut, NombreEmp = nombre, Direccion = direccion, Ciudad = ciudad, Telefono = telefono });
            context.SaveChanges();
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
