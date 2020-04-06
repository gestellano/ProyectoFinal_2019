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
        [HttpGet]
        public String BuscarCliente(String rut)
        {
            using (var context = new BaseDeDatosContext())
            {
                 var client = context.Clientes.Find(rut);
                
                if(client == null)
                {
                    return string.Empty;
                }
                else
                { 
                return "ciudad=" + client.Ciudad        +";"+
                       "nombreEmp=" + client.NombreEmp  + ";" +
                       "telefono=" + client.Telefono    + ";" +
                       "direccion=" + client.Direccion  + ";" +
                       "rut="    + client.Rut;
                }

            }

         
        }


        // GET: api/Cliente        
       // [Route("AgregarCliente")]
        [HttpGet]
        public void AgregarCliente(string rut, string nombre, string direccion, string ciudad, string telefono)
        {          
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Clientes.Add(new Cliente() { Rut = rut, NombreEmp = nombre, Direccion = direccion, Ciudad = ciudad, Telefono = telefono });
            context.SaveChanges();
            
        }

        //Modificar Cliente
        [HttpGet]
        public void ModificarCliente(string rut, string nombre, string direccion, string ciudad, string telefono, string modificar)
        {
            BaseDeDatosContext context = new BaseDeDatosContext();
            var ClienteModif = context.Clientes.First<Cliente>();
            ClienteModif.Rut = rut;
            ClienteModif.NombreEmp = nombre;
            ClienteModif.Ciudad = ciudad;
            ClienteModif.Direccion = direccion;
            ClienteModif.Telefono = telefono;
            context.SaveChanges();

        }



       
    }
}
