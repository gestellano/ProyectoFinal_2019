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
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        //// GET: api/Cliente
        // public List<Cliente> Get()
        // {
        //     BaseDeDatosContext baseDatos = new BaseDeDatosContext();
        //     return (from cliente in baseDatos.Clientes
        //             select cliente).ToList();
        // }


        // GET: api/Cliente/5
        public string Get(String rut)
        {

            BaseDeDatosContext context = new BaseDeDatosContext();
            var client = context.Clientes.Find(rut);
            String clienteEncontrado = JsonConvert.SerializeObject(client);
            return clienteEncontrado;

        }

            // POST: api/Cliente

        [Route("AgregarCliente")]
        [HttpPost]
        public void AgregarCliente(string rut, string nombre, string direccion, string ciudad, string telefono)
        {
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Clientes.Add(new Cliente() { Rut = rut, NombreEmp = nombre, Direccion = direccion, Ciudad = ciudad, Telefono = telefono });
            context.SaveChanges();
        }

        // PUT: api/Cliente/5
        //public void Put(int id, [FromBody]string value)

        //{
        //}

        // DELETE: api/Cliente/5
        //public void Delete(int id)
        //{
        //}
    }
}
