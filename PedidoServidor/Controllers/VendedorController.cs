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
    public class VendedorController : ApiController
    {
        [HttpGet]
        public string Login(string nickname)
        {
            using (var context = new BaseDeDatosContext())
            {
                var vend = context.Vendedores.Find(nickname);
                if (vend == null)
                {
                    return string.Empty;
                }
                else
                {
                    return "nickname=" + vend.Nickname + ";" +
                           "password=" + vend.Password;
                }
            }
        }

        //AltaVendedor
        [HttpGet]
        public void AgregarVendedor(string nombre, string mail, string celular, string nickname, string password,string zonaTrabajo, bool tieneVehiculo)
        {
            BaseDeDatosContext context = new BaseDeDatosContext();
            context.Vendedores.Add(new Vendedor() { Nombre = nombre, Mail=mail,Celular=celular,Nickname=nickname,Password=password,ZonaTrabajo=zonaTrabajo,TieneVehiculo=tieneVehiculo });
            context.SaveChanges();

        }
    }
}
